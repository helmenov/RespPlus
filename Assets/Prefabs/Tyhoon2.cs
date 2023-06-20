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
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "chanpon")
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "torukorice")
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);

        }

        if ((collision.gameObject.tag == "ufo") && (transform.position.z <= 80))
        {
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "seria")
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(gameObject);

        }

    }

}
