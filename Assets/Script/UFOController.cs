using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    private Rigidbody rb;
  //  public GameObject laserPrefab;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.z>=300)
        {
            rb.AddForce(30f, -10f, -40f);
            //transform.Translate(3f,-1f,-4f);

        }
           
        

        if ((transform.position.x >= 10)&& (transform.position.z >= 20))
        {
           rb.AddForce(-40f, 10f, 0);
           // transform.Translate(-4f, 2f, -4f);

        }

        if((transform.position.z>=50)&&(transform.position.z<=100))
        {
           rb.AddForce(0, 0, 300f);

        }

      //  if ((transform.position.z <= 90))
      //  {

      //      GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
      //      Rigidbody laserRb = laser.GetComponent<Rigidbody>();
//
     //   }
        



        if (transform.position.y <= -10 |transform.position.y>=100)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトのtagが"Cube"ならば
        if ((collision.gameObject.tag == "meteorite"))
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
        }
    }

}
