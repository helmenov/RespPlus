using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z >= 100)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �����Փ˂�������I�u�W�F�N�g��tag��"Cube"�Ȃ��
        if (collision.gameObject.tag == "kastera")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            ShootingController.instance.kastera();

        }

        if (collision.gameObject.tag == "chanpon")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

            ShootingController.instance.chanpon();

        }

        if (collision.gameObject.tag == "torukorice")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

            ShootingController.instance.trukorice();

        }

        if ((collision.gameObject.tag=="ufo")&&(transform.position.z<=80))
        {
            Destroy(collision.gameObject);
            ShootingController.instance.UFO();

        }

    }

}
