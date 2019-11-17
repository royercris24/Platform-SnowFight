using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D otherCol)
    {
        SceneManager.LoadScene("Win");
    }
}
