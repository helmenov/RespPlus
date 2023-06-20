using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APC : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        transform.Rotate(30 * Time.deltaTime, 0, 0);
        float y = Input.GetAxis("Horizontal") * speed;
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(-50 * Time.deltaTime, 0, 0);

        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(0, y, 0);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(0, y, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
