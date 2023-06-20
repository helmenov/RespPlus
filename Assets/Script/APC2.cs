using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class APC2 : MonoBehaviour
{
    private Rigidbody rb;
    //private float speed = 20f;

    //��]���x
   // [Range(0f, 1f)] public float rotationSpeed = 1f;
    //private float rotation_x = 0f;


    // x�������̈ړ��͈͂̍ŏ��l
    [SerializeField] private float _minX = -10;

    // x�������̈ړ��͈͂̍ő�l
    [SerializeField] private float _maxX = 10;

    [Range(-40f, 0f)] public float max_rotation_x = -40f;
    //�c�����̊p�x(����)
    [Range(0f, 40f)] public float min_rotation_x = 40f;

    public Text gameoverText;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameoverText.text = "";

    }


    void FixedUpdate()
    {
      
       transform.Rotate(30 * Time.deltaTime, 0, 0);

       // float y = Input.GetAxis("Horizontal") * speed;

       if (Input.GetKey(KeyCode.Space))
       {
            

            transform.Rotate(-50 * Time.deltaTime, 0, 0);

       }
       // if (Input.GetKeyDown(KeyCode.LeftArrow))
       // {
           // rb.AddForce(0, y, 0);

       // }
       // if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
          //  rb.AddForce(0, y, 0);

       // }

       var pos = transform.position;

       //x�������̈ړ��͈͐���
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

        transform.position = pos;




    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // �����Փ˂�������I�u�W�F�N�g��tag��"Cube"�Ȃ��
        if ((collision.gameObject.tag == "meteorite"))
        {
            gameoverText.text = "Game Over";

        }
        if ((collision.gameObject.tag == "laser"))
        {
            gameoverText.text = "Game Over";

        }
        if((collision.gameObject.tag == "planet"))
        {
            gameoverText.text = "Game Over";

        }
        if ((collision.gameObject.tag == "ufo"))
        {
            gameoverText.text = "Game Over";

        }
        if ((collision.gameObject.tag == "cureitem"))
        {
            gameoverText.text = "Game Over";

        }




    }


}
