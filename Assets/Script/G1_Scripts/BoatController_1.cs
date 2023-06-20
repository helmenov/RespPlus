using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoatController_1 : MonoBehaviour
{
    void FixedUpdate()
    {
        if (transform.position.y <= -0.8)
        {
            SceneManager.LoadScene("Gameover");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �����Փ˂�������I�u�W�F�N�g��tag��"   "�Ȃ��
        if ((collision.gameObject.tag == "typhoon"))
        {
            SceneManager.LoadScene("Gameover");
            
        }
       
    }
}
