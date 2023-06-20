using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typhoonController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public GameObject ball;

    [SerializeField] float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(player.transform);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, -10f);

        //transform.Rotate(0,30 * Time.deltaTime, 0);

        transform.LookAt(player.transform);

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);


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
