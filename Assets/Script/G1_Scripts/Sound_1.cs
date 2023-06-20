using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent (typeof(AudioSource))]
public class Sound_1 : MonoBehaviour
{
  //public Fourie fourie;
    float[] data;
//    Fourie fourie;
 //   Liftering liftering;
    int samplingRange = 512; //1024 OR 512
    int thousand_index = 24;   // 47 OR 24
    float[] hairetu;
    public boatController2_1 boat;
    public ShieldManager_1 baria;
    public ShootingController_1 shooting;

    //public Text text;

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
    double[] Ha_array = {0.09666242,
0.1010209,
0.04417039,
0.005689631,
0.005637815,
0.01925762,
0.03026361,
0.0365145,
3.82E-02,
0.01092663,
1.79E-03,
4.57E-03,
0.01878265,
5.50E-02,
0.06935102,
4.09E-02,
2.39E-02,
1.27E-02,
2.70E-02,
4.01E-02,
2.92E-02,
2.26E-02,
9.22E-03,
3.89E-02
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
    // Start is called before the first frame update
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
            //text.text = devName;


        }
        
    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        //Fourie fourie = GetComponent<Fourie>();
        //Liftering liftering = GetComponent<Liftering>();
        //InputFieldManager inputfield = GetComponent<InputFieldManager>();
        var spectrum = GetComponent<AudioSource>().GetSpectrumData(samplingRange, 0, FFTWindow.Hamming);
        string bun = "";
        
        for (int i = 1; i < spectrum.Length - 1; ++i) {
            Debug.DrawLine(
                    new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), 
                    new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), 
                    Color.red);
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





        double Fu_euclid = 0;
        double Ha_euclid = 0;
        double Pa_euclid = 0;
        double max_amplitude = 0;
        double max2_amplitude = 0;
        int max_index = 0;
        
        for (int i = 0; i < thousand_index; i++){
            Fu_euclid = Fu_euclid + (Fu_array[i]-spectrum[i])*(Fu_array[i]-spectrum[i]);
            Ha_euclid = Ha_euclid + (Ha_array[i]-spectrum[i])*(Ha_array[i]-spectrum[i]);
            Pa_euclid = Pa_euclid + (Pa_array[i] - spectrum[i]) * (Pa_array[i] - spectrum[i]);
            if (max_amplitude < spectrum[i]){
                max_amplitude = spectrum[i];
                max_index = i;
            }
        }

        double Fu_odds = 1/(1+Math.Sqrt(Fu_euclid));
        double Ha_odds = 1/(1+Math.Sqrt(Ha_euclid));
        double Pa_odds = 1 / (1 + Math.Sqrt(Pa_euclid));
        if ((Ha_odds >= 0.83) && (max_amplitude >= 0.1))
        {
            Debug.Log("はっ  Fu=" + Fu_odds.ToString() + " Ha=" + Ha_odds.ToString());
            Debug.Log(bun);
            shooting.shooting();
        }
       

        //else if ((Fu_odds >= 0.67)&&(Ha_odds >= 0.67)){
          //  if((spectrum[0] <= spectrum[1])&&(max_amplitude >= 0.1)){
           // Debug.Log("ふー  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString());
            //Debug.Log(bun);
          //  }
            
       // }
        
        else if((Fu_odds >= 0.70)&&(max_amplitude >= 0.1)){
            Debug.Log("ふー  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString());
            Debug.Log(bun);
            boat.upmove();

        }
        if ((Pa_odds >= 0.80) && (max_amplitude >= 0.1))
        {
            //Debug.Log("ぱっ  Fu=" + Fu_odds.ToString()+ " Ha=" + Ha_odds.ToString() + " Pa=" + Pa_odds.ToString());
            //Debug.Log(bun);
            Debug.Log("Pa");
            baria.baria();

            //socre_text.text = "ぱっ  " + elapsedTime.ToString("0.00");
        }
              
    }
}
