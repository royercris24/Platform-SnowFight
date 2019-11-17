using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour
{
    private const string Name = "Niveles 1";
    private Scene Niveles1;

    // Use this for initialization
    void Start()
    {
        Niveles1 = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player 1")
        {
            SceneManager.LoadScene(Name);
        }
    }
}
