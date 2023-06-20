using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class APC4 : MonoBehaviour
{
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

    

    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.J))
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
        else if (Input.GetKey(KeyCode.L))
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

        //����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.I))
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
        else if (Input.GetKey(KeyCode.K))
        {
            //�J�����̏c�����̊p�x�͈̔͂��w��
            if (rotation_x > min_rotation_x)
            {
                //�͈͊O�̂Ƃ�return���ď��������Ȃ�
                return;
            }
            //���݂̉�]�p�x��ύX
            rotation_x += rotationSpeed;
            //x�������ɏ�����ɉ�]
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }
    }
}
