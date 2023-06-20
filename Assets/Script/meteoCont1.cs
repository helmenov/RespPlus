using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoCont1 : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;

    // public GameObject target;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player.transform);
       // StartCoroutine("MeteoriteShot");
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform);

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);


        if (transform.position.z <= 0)
        {
            Destroy(gameObject);
        }

    }

     
            
        
    

}
