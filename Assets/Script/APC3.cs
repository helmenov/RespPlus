using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APC3 : MonoBehaviour
{
    private Rigidbody rb;
    //��]���x
    [Range(0f, 1f)] public float rotationSpeed = 1f;
    //�c�����̊p�x(�㑤�j
    [Range(0f, 90f)] public float max_rotation_x = 80f;
    //�c�����̊p�x(����)
    [Range(0f, 90f)] public float min_rotation_x = 80f;
    //���E�����̍ő�p�x(���E�Ώ̂̂��ߍő�̂�)
    [Range(0f, 180f)] public float max_rotation_y = 180f;
    //���݂̉�]�p�x
    private float rotation_x = 0f;
    private float rotation_y = 0f;
 





    public Text gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameoverText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);


        //����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.U))
        {
            //�J�����̏c�����̊p�x�͈̔͂��w��
            if (rotation_x < -max_rotation_x)
            {
                //�͈͊O�̂Ƃ�return���ď��������Ȃ�
                return;
                

            }
            //���݂̉�]�p�x��ύX
            rotation_x -= rotationSpeed;
            //x�������ɏ�����ɉ�]
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
           
        }

        //�����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.I))
        {
            //�J�����̉��������̊p�x�͈̔͂��w��
            if (rotation_y < -max_rotation_y)
            {
                //�͈͊O�̂Ƃ�return���ď��������Ȃ�
                 return;
              
            }
            //���݂̉�]�p�x��ύX
            rotation_y -= rotationSpeed;
            //y�������ɍ�����rotationSpeed�x��]
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }
        //�E���L�[�������ꂽ�Ƃ�
        else if (Input.GetKey(KeyCode.O))
        {
            //�J�����̉��E�����̊p�x�͈̔͂��w��
            if (rotation_y > max_rotation_y)
            {
                //�͈͊O�̂Ƃ�return���ď��������Ȃ�
                return;
                
            }
            //���݂̉�]�p�x��ύX
            rotation_y += rotationSpeed;
            //y�������ɍ�����rotationSpeed�x��]
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        // �����Փ˂�������I�u�W�F�N�g��tag��"   "�Ȃ��
        if ((collision.gameObject.tag == "meteorite"))
        {
            gameoverText.text = "Game Over";

        }
        if ((collision.gameObject.tag == "laser"))
        {
            gameoverText.text = "Game Over";

        }
        if ((collision.gameObject.tag == "planet"))
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
