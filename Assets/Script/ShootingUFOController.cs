using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingUFOController : MonoBehaviour
{
    public GameObject obj;
    public GameObject parentObj; /* êeóvëf */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.z<=90))
        {

            Instantiate(obj, parentObj.transform);

        }
    }
}
