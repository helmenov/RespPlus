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
        // もし衝突した相手オブジェクトのtagが"Cube"ならば
        if (collision.gameObject.tag == "typhoon")
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
        }

    }
}
   
