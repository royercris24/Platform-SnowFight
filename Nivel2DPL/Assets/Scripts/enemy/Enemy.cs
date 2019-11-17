using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float visionRsdius;
    public float speed;

    public bool trow;
    public float timeTrow;

    public GameObject snowBall;
    public Transform throwPoint;

    private Animator anim;

    GameObject Player1;

    Vector3 initialPosition;

    // Use this for initialization
    void Start()
    {

        Player1 = GameObject.FindGameObjectWithTag("Player 1");

        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 target = initialPosition;

        float dist = Vector3.Distance(Player1.transform.position, this.transform.position);
        if (dist < visionRsdius) target = Player1.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, speed);

        if (dist < visionRsdius && _elapseTime > timeTrow)
        {
            _elapseTime = 0f;

            Throw();
        }

        Debug.DrawLine(transform.position, target, Color.green);

        _elapseTime += Time.deltaTime;
    }

    void Throw()
    {
        var snowBall = (GameObject)Instantiate(this.snowBall, throwPoint.position, throwPoint.rotation);
        SnowBall snowBallBehaviour = snowBall.GetComponent<SnowBall>();

        Vector3 direction = Player1.transform.position - this.transform.position;
        direction.Normalize();
        snowBallBehaviour.SetDirection(direction);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRsdius);
    }

    private float _elapseTime = 0f;
}
