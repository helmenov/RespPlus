using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typhoonManeger : MonoBehaviour
{
    private float vecX;
    private float vecY;
    [SerializeField] GameObject[] ball;

    private float time;

    private int N;
    //これはゲームオブジェクトの長さです

    private int n;
    //ボールのどれかを使う。



    // Start is called before the first frame update
    void Start()
    {
        time = 10.0f;
        
        N = ball.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            time = 10.0f;
            n = Random.Range(0, N);

            if (n == 0)
            {
                Typhoon1();
            }
        }

    }

    void Typhoon1()
    {
        vecX = Random.Range(-50, 50);
        vecY = Random.Range(1, 1);
        Instantiate(ball[0], new Vector3(vecX, vecY, 200), Quaternion.identity);
    }
}
