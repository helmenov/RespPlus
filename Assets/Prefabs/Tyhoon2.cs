using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyhoon2 : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, -10f);
        transform.Rotate(new Vector3(0, 360, 0) * Time.deltaTime, Space.World);

        if (transform.position.z <= 0)
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "kastera")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "chanpon")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "torukorice")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

        }

        if ((collision.gameObject.tag == "ufo") && (transform.position.z <= 80))
        {
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "seria")
        {
            // �Փ˂�������I�u�W�F�N�g���폜����
            Destroy(gameObject);

        }

    }

}
