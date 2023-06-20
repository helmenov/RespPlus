using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{

    [SerializeField] private float speed = 5.0f;
    public int Hitpoint = 10;
    public Slider slider;
    private int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        currentHP = Hitpoint;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(currentHP);
        this.transform.position += transform.forward*Time.deltaTime*speed;
       // if (Input.GetKey(KeyCode.Space))
        //{
        //    this.transform.position += transform.up * Time.deltaTime * speed2;

            // Vector3 force;

            //force = transform.up * speed2;

            // rb.AddForce(force, ForceMode.Impulse);

       // }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "chanpon"))
        {
            SceneManager.LoadScene("Gameover");
            
        }
        // �����Փ˂�������I�u�W�F�N�g��tag��"   "�Ȃ��
        if ((collision.gameObject.tag == "kastera"))
        {
            //SceneManager.LoadScene("Gameover");
            currentHP = currentHP - 1;
            Debug.Log("Kastera colliison");
            if(currentHP < 1){
                SceneManager.LoadScene("GameClear");
            }
            
        }
        if ((collision.gameObject.tag == "kakuni"))
        {
            //SceneManager.LoadScene("Gameover");
            currentHP = currentHP - 1;
            Debug.Log("Kakuni colliison");
            if(currentHP < 1){
                SceneManager.LoadScene("GameClear");
            }
        }

        slider.value = (float)currentHP / (float)Hitpoint;
    }
}
