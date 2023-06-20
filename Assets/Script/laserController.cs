using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);


        if (transform.position.z <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトのtagが"Cube"ならば
        if (collision.gameObject.tag == "meteorite" | collision.gameObject.tag == "planet" | collision.gameObject.tag == "star")
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
        }
    }

}
