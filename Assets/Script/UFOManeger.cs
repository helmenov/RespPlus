using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOManeger : MonoBehaviour
{
    public GameObject sphereObject;
    public GameObject cubeObject;
    public GameObject waaObject;


    // Start is called before the first frame update
    void Start()
    {
        //sphereObject.SetActive(false);
        cubeObject.SetActive(false);
        waaObject.SetActive(false);
        StartCoroutine("SphereAppear");
    }


    IEnumerator SphereAppear()
    {
        yield return new WaitForSeconds(5.0f); //20
        sphereObject.SetActive(true);
        StartCoroutine("CubeAppear");
    }

    IEnumerator CubeAppear()
    {
        yield return new WaitForSeconds(15.0f);
        cubeObject.SetActive(true);
        StartCoroutine("WaaAppear");
    }

    IEnumerator WaaAppear()
    {
        yield return new WaitForSeconds(15.0f);
        waaObject.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
