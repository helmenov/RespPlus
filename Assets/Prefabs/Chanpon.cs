using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chanpon : MonoBehaviour
{

    private Rigidbody rb;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        //rb.AddForce(0, 0, -10f);

        transform.Rotate(60 * Time.deltaTime, 87 * Time.deltaTime, -20 * Time.deltaTime);
    }
}
