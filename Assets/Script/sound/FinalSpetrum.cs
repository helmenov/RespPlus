using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]
public class FinalSpetrum : MonoBehaviour
{
    //public Fourie fourie;
   // public GameObject score_object = null;
    private float elapsedTime;
    float[] data;
    //Fourie fourie;
   // Liftering liftering;
    int samplingRange = 512; //1024 OR 512
    int thousand_index = 24;   // 47 OR 24
    int Ha_Key = 0;
    int Ha_depse = 100;
    float[] hairetu;
    public boatController2 boat;
  

    double[] Fu_array = {0.04663889,
0.08273548,
0.1707033,
0.1037671,
0.05075672,
0.02912107,
0.07029577,
0.02660729,
0.07701397,
0.07358543,
0.03582431,
0.034128,
0.06408661,
0.0669658,
0.04760632,
0.03390676,
0.04892594,
0.04976312,
0.0779156,
0.08174721,
0.05171812,
0.03128907,
0.03644949,
0.0191151
};
    double[] Ha_array = {0.1481025,
0.06061252,
0.01815829,
0.006302766,
0.006274845,
0.01636221,
0.01588225,
0.005029309,
0.003100642,
0.006800596,
0.009374877,
0.02163457,
0.05241839,
0.03529503,
0.003242796,
0.008207725,
0.01115627,
0.01414298,
0.01138152,
0.003622001,
0.00205031,
0.004586421,
0.01217962,
0.01251459
};
    double[] Pa_array = {0.03245861,
0.04191279,
0.01490102,
0.02225155,
0.009038828,
0.01731531,
0.005591091,
0.02210945,
1.17E-02,
1.08E-02,
2.92E-02,
9.25E-02,
1.35E-01,
1.39E-01,
5.11E-02,
1.34E-02,
9.49E-03,
1.22E-02,
1.40E-02,
1.42E-02,
8.40E-03,
9.48E-03,
1.78E-02,
7.05E-03,
};


    void Start()
    {
        var audio = GetComponent<AudioSource>();
        //fourie = GetComponent<Fourie>();
        //liftering = GetComponent<Liftering>();
        hairetu = new float[samplingRange];
        if((audio != null)&&(Microphone.devices.Length > 0)){
            string devName = Microphone.devices[0];
            int minFreq, maxFreq;
            Microphone.GetDeviceCaps(devName, out minFreq, out maxFreq);
            
            audio.clip = Microphone.Start(devName, true, 1, 44100);
            audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Fourie fourie = GetComponent<Fourie>();
        //Liftering liftering = GetComponent<Liftering>();
        //InputFieldManager inputfield = GetComponent<InputFieldManager>();
       // Text socre_text = score_object.GetComponent<Text>();
        elapsedTime = Time.time;
        var spectrum = GetComponent<AudioSource>().GetSpectrumData(samplingRange, 0, FFTWindow.Hamming);
        string bun = "";
        
        for (int i = 1; i < spectrum.Length - 1; ++i) {
            if(i < thousand_index + 1)
            {
                bun = bun + spectrum[i-1].ToString() + "\n";
            }
            //bun = bun + spectrum[i].ToString() + "\n";
            if (i <= samplingRange - 2){
                hairetu[i-1] = spectrum[i];
            }
        }
        hairetu[samplingRange - 2] = hairetu[samplingRange - 3];
        hairetu[samplingRange - 1] = hairetu[samplingRange - 3];


if(Ha_Key != 0){
            Ha_Key = Ha_Key - 1;
        }
        
        double Fu_euclid = 0;
        double Ha_euclid = 0;
        double Pa_euclid = 0;
        double max_amplitude = 0;
        double max2_amplitude = 0;
        int max_index = 0;
        int max2_index = 0;
        for (int i = 0; i < thousand_index; i++){
            Fu_euclid = Fu_euclid + (Fu_array[i]-spectrum[i])*(Fu_array[i]-spectrum[i]);
            Ha_euclid = Ha_euclid + (Ha_array[i]-spectrum[i])*(Ha_array[i]-spectrum[i]);
            Pa_euclid = Pa_euclid + (Pa_array[i]-spectrum[i])*(Pa_array[i]-spectrum[i]);
            if(max_amplitude < spectrum[i]){
                max_amplitude = spectrum[i];
                max_index = i;
            }
            if(i >= 9){
                if(max2_amplitude < spectrum[i]){
                    max2_amplitude = spectrum[i];
                    max2_index = i;
                }
            }
        }

        double Fu_odds = 1/(1+Math.Sqrt(Fu_euclid));
        double Ha_odds = 1/(1+Math.Sqrt(Ha_euclid));
        double Pa_odds = 1/(1+Math.Sqrt(Pa_euclid));

        if((Pa_odds >= 0.69)&&(max_amplitude >= 0.1)&&((max_index == 11)||(max_index == 12)||(max_index == 13))){
            //Debug.Log("ぱっ  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString() + " Pa=" + Pa_odds.ToString());
            //Debug.Log(bun);
            Debug.Log("Pa");
           //socre_text.text = "ぱっ  " + elapsedTime.ToString("0.00");
        }
        else if((Ha_Key == 0)&&(Fu_odds >= 0.79)&&(Ha_odds >= 0.79)&&(max_amplitude >= 0.1)){
            if(Ha_odds >= 0.78){
                if(((max2_index >= 13)&&(max2_index <= 15))||(max2_index >= 20)){
                    Ha_Key = Ha_depse;
                    //Debug.Log("はっ2  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString() + "Ha_Key == " + Ha_Key.ToString());
                    //Debug.Log(bun);
                    Debug.Log("Ha1");
                    //socre_text.text = "はっ1  " + elapsedTime.ToString("0.00");
                }
            }
            else if(((max_index == 1)||(max_index == 2)||(max_index == 3))&&(spectrum[0] >= 0.025)){
                if(!(max2_index < 12)&&(max2_amplitude >= 0.006)&&!(spectrum[4] >= 0.05)){
                    //Ha_Key = Ha_depse;
                    //Debug.Log("はっ星  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString()+"Ha_Key == " + Ha_Key.ToString());
                    //Debug.Log(bun);
                    //Debug.Log("Ha2");
                    //socre_text.text = "はっ2  " + elapsedTime.ToString("0.00");
                }
                else{
                    //Debug.Log("ふー  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString()+"Ha_Key == " + Ha_Key.ToString());
                    //Debug.Log(bun);
                    Debug.Log("Hu");
                    //socre_text.text = "ふー  " + elapsedTime.ToString("0.00");
                    boat.upmove();
                }
            }

        }
        
        else if((Ha_Key == 0)&&(Fu_odds >= 0.69)&&(max_amplitude >= 0.1)&&(spectrum[0] >= 0.125)){
            //Debug.Log("ふー  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString()+"Ha_Key == " + Ha_Key.ToString());
            //Debug.Log(bun);
            Debug.Log("Hu");
           // socre_text.text = "ふー　" + elapsedTime.ToString("0.00");
            boat.upmove();
        }
        else if((Ha_Key == 0)&&(Ha_odds >= 0.69)&&(max_amplitude >= 0.1)&&(max_index == 0)&&(max2_index >= 11)&&(max2_amplitude >= 0.00197)
        &&!(spectrum[4] >= 0.05)&&!(spectrum[5] >= 0.05)){
            if(Ha_odds >= 0.88){
                if((((max2_index >= 13)&&(max2_index <= 15))||(max2_index >= 20))&&(max2_amplitude >= 0.0035)){
                    Ha_Key = Ha_depse;
                    //Debug.Log("はっ強  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString() + "172=" + spectrum[3].ToString()+"Ha_Key == " + Ha_Key.ToString());
                    //Debug.Log(bun);
                    Debug.Log("Ha3");
                   // socre_text.text = "はっ3　" + elapsedTime.ToString("0.00");
                }
            }
            else if(max2_amplitude >= 0.0065){
                Ha_Key = Ha_depse;
                //Debug.Log("はっ弱  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString()+"Ha_Key == " + Ha_Key.ToString());
                //Debug.Log(bun);
                Debug.Log("Ha4");
               // socre_text.text = "はっ4　" + elapsedTime.ToString("0.00");
            }
        }
    }
}