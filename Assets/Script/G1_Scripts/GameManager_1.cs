using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_1 : MonoBehaviour
{
    private float vecX1;
    private float vecY1;

    [SerializeField] GameObject[] ball1;

    private float time;

    private int N;
   //����̓Q�[���I�u�W�F�N�g�̒����ł�
  
    private int n;
    //�{�[���̂ǂꂩ���g���B

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        N = ball1.Length ;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
            time = 1.0f;
            n = Random.Range(0, N);

            if (n == 0)
            {
                tama1();
            }

            if (n == 1)
            {
                tama2();
            }

            if (n == 2)
            {
                tama3();
            }

        }
    }

    void  tama1()
    {
        vecX1 = Random.Range(-20, 20);
        vecY1 = Random.Range(3, 20);
        Instantiate(ball1[0], new Vector3(vecX1, vecY1, 100), Quaternion.identity);



    }

    void tama2()
    {
        
        vecX1 = Random.Range(-20, 20);
        vecY1 = Random.Range(3, 20);
        Instantiate(ball1[1], new Vector3(vecX1, vecY1, 300), Quaternion.identity);



    }

    void tama3()
    {
        
        vecX1 = Random.Range(-20, 20);
        vecY1 = Random.Range(3, 20);
        Instantiate(ball1[2], new Vector3(vecX1, vecY1, 200), Quaternion.identity);



    }
}
