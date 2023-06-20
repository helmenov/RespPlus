using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shieldManeger : MonoBehaviour
{
    //bullet�v���n�u
    public GameObject StarObject;
    //�e�����������|�W�V������ۗL����Q�[���I�u�W�F�N�g
    public GameObject StarPos;

    public GameObject BoatPos;

    //�e�ۂ̃X�s�[�h
    public float speed = 1500f;


    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.A))
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

    }

    public void baria()
    {
        //ball���C���X�^���X�����Ĕ���
        GameObject createdStarObject = Instantiate(StarObject) as GameObject;
        createdStarObject.transform.position = BoatPos.transform.position;

        //���˃x�N�g��
        Vector3 force;
        //���˂̌����Ƒ��x������
        force = StarPos.transform.forward * speed;
        // Rigidbody�ɗ͂������Ĕ���
        createdStarObject.GetComponent<Rigidbody>().AddForce(force);
    }

}

