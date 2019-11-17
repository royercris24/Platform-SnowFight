using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    public GameObject pause;
    public void resume()
    {
        pause.SetActive(false);
    }

    public void palyer()
    {
        SceneManager.LoadScene("1 Player");
    }

    public void player2()
    {
        SceneManager.LoadScene("2 Players");
    }

    public void restart()
    {
        SceneManager.LoadScene("Niveles 1");
    }

    public void restart2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void restart3()
    {
        SceneManager.LoadScene("SampleScene2");
    }

    public void exitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Debug.Log("Exit button pressed");
        Application.Quit();
    }


}
