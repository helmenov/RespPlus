using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton2 : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("GameScene1");
    }
}
