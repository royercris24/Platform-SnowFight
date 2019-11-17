using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelomovil : MonoBehaviour
{

    private Vector3 startPos;
    public Transform target;
    public float speed;
    private bool moveUp;
    // Use this for initialization
    void Start()
    {

        startPos = transform.position;
        moveUp = true;

    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        if (transform.position == target.position)
        {
            moveUp = false;
        }
        else if (transform.position == startPos)
        {
            moveUp = true;
        }
        if (moveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

    }
}



