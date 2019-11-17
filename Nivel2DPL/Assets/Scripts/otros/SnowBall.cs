using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public float ballSpeed;

    private Rigidbody2D theRB;

    public GameObject snowBallEffect;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = ballSpeed * _direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }
         if (other.tag == "Player 2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
        else if (other.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().HurtEnemy();
        }

        Debug.Log("OnTriggerEnter2D: " + other.name);
        Instantiate(snowBallEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private Vector2 _direction;
}
