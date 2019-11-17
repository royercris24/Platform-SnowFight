using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject Enemy;

    public int P1Life;
    public int P2Life;
    public int EnemyLife;

    public GameObject gameOver;

    public GameObject pause;

    public GameObject[] P1Stick;
    public GameObject[] P2Stick;
    public GameObject[] EnemyStick;

    public AudioSource hurtSound;

    public void HurtP1()
    {
        P1Life -= 1;

        for (int i = 0; i < P1Stick.Length; i++)
        {
            if (P1Life > i)
            {
                P1Stick[i].SetActive(true);
            }
            else
            {
                P1Stick[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }

    public void HurtP2()
    {
        P2Life -= 1;

        for (int i = 0; i < P2Stick.Length; i++)
        {
            if (P2Life > i)
            {
                P2Stick[i].SetActive(true);
            }
            else
            {
                P2Stick[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }

    public void HurtEnemy()
    {
        EnemyLife -= 1;

        for (int i = 0; i < EnemyStick.Length; i++)
        {
            if (EnemyLife > i)
            {
                EnemyStick[i].SetActive(true);
            }
            else
            {
                EnemyStick[i].SetActive(false);
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckPlayerLifes();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //TODO: Hacer el pause
            pause.SetActive(true);
        }
    }


    private void CheckPlayerLifes()
    {
        if (P1Life <= 0)
        {
            player1.SetActive(false);
            gameOver.SetActive(true);
        }

        if (P2Life <= 0)
        {
            player2.SetActive(false);
            gameOver.SetActive(true);
        }

        if (EnemyLife <= 0)
        {
            Enemy.SetActive(false);
        }
    }


}
