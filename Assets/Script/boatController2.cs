using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatController2 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float speed2 = 1.0f;
    [SerializeField] private float maxvecY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position -= transform.forward*Time.deltaTime*speed;
       // if (Input.GetKey(KeyCode.Space))
        //{
        //    this.transform.position += transform.up * Time.deltaTime * speed2;

            // Vector3 force;

            //force = transform.up * speed2;

            // rb.AddForce(force, ForceMode.Impulse);

       // }
        if (this.transform.position.z >= maxvecY)
        {
            this.transform.position = new Vector3(this.transform.position.x, maxvecY, this.transform.position.z);
        }
    }

    public void upmove()
    {
        this.transform.position += transform.forward * Time.deltaTime * speed2;
        Debug.Log(1);

    }
    
}
