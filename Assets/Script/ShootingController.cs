using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShootingController : MonoBehaviour
{
    //bullet�v���n�u
    public GameObject StarObject;
    //�e�����������|�W�V������ۗL����Q�[���I�u�W�F�N�g
    public GameObject StarPos;

    public GameObject BoatPos;

    //�e�ۂ̃X�s�[�h
    public float speed = 1500f;


    public int scorecounter;
     
    private int Startscorecounter = 000000;

    public Text scoreText;


    public static ShootingController instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
     
            
    }

    private float timer = 0;


    
       




    // Start is called before the first frame update
    void Start()
    {
        scorecounter = Startscorecounter;

        SetCountText();

    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.S))
         {
                  //ball���C���X�^���X�����Ĕ���
                  GameObject createdStarObject = Instantiate(StarObject) as GameObject;
                  createdStarObject.transform.position = StarPos.transform.position;

                  //���˃x�N�g��
                  Vector3 force;
                  //���˂̌����Ƒ��x������
                  force = StarPos.transform.forward * speed;
                  // Rigidbody�ɗ͂������Ĕ���
                  createdStarObject.GetComponent<Rigidbody>().AddForce(force);

         }*/

        timer += Time.deltaTime;

       
    }

    public void shooting()
    {
        if(timer>0.4f)
        {
            //ball���C���X�^���X�����Ĕ���
            GameObject createdStarObject = Instantiate(StarObject) as GameObject;
            Vector3 create_pos = createdStarObject.transform.position;
            create_pos.x = BoatPos.transform.position.x;
            create_pos.y = 0.35f;
            create_pos.z = BoatPos.transform.position.z + 5;
            createdStarObject.transform.position = create_pos;

            //���˃x�N�g��
            Vector3 force;
            //���˂̌����Ƒ��x������
            force = StarPos.transform.forward * speed;
            // Rigidbody�ɗ͂������Ĕ���
            createdStarObject.GetComponent<Rigidbody>().AddForce(force);
            timer = 0;

        
        }
        
            
    }
    

    public void kastera()
    {
        scorecounter += 100;
        SetCountText();
    }

    public void chanpon()
    {
        scorecounter += 500;
        SetCountText();
    }

    public void trukorice()
    {
        scorecounter += 1000;
        SetCountText();
    }
    public void UFO()
    {
        scorecounter += 5000;
        SetCountText();
    }




    void SetCountText()
    {
        scoreText.text = "score : " + scorecounter.ToString();

    }


}
