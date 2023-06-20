using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakuniController : MonoBehaviour
{
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z >= 200)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "enemy"))
        {
            //SceneManager.LoadScene("Gameover");
            if (transform.position.z <= 40)
            {
                Destroy(gameObject);
            }
            
        }
    }

}
