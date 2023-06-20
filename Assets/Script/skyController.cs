using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyController : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, -50f);

        transform.Rotate(0, 30 * Time.deltaTime, 0);




        if (transform.position.z <= -10)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
