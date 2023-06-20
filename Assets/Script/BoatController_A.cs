using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BoatController_A : MonoBehaviour
{
    //public Text gameoverText;

    // Start is called before the first frame update
    void Start()
    {
       // gameoverText.text = "";
    }

    // Update is called once per frame
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
