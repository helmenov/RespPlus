using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (transform.position.z >= 20)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        // �����Փ˂�������I�u�W�F�N�g��tag��"Cube"�Ȃ��
        if (collision.gameObject.tag == "typhoon")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
        }

    }
}
   
