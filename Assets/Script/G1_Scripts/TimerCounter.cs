using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCounter : MonoBehaviour
{
    //カウントアップ
    private float countup = 20.0f;

    //タイムリミット
    public float timeLimit = 0.0f;

    //時間を表示するText型の変数
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        //時間をカウントする
        countup -= Time.deltaTime;

        //時間を表示する
        timeText.text = "残り時間  " + countup.ToString("f1") + "  秒";

        if(countup <= timeLimit)
        {
            SceneManager.LoadScene("GameClear");
            //timeText.text = "時間になりました！";
        }
    }
}