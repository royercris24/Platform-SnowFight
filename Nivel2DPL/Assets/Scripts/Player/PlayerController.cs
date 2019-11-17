using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwball;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;

    public GameObject snowBall;
    public Transform throwPoint;

    public Collider2D wallBox;

    public AudioSource throwSound;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);


        if (Input.GetKey(left))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (!TouchWall(Vector2.left))
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            }
        }
        else if (Input.GetKey(right))
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (!TouchWall(Vector2.right))
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            }
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKeyUp(throwball))
        {
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            SnowBall snowBallBehaviour = ballClone.GetComponent<SnowBall>();
            snowBallBehaviour.SetDirection(this.transform.localScale.x == 1f ? Vector2.right : Vector2.left);
            anim.SetTrigger("Throw");

            throwSound.Play();
        }



        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);

    }

    private bool TouchWall(Vector2 direction)
    {
        // Comprobamos con el collider derecho
        return wallBox.OverlapCollider(_contactFilter2d, _overlapColliders) > 1f;
    }

    // Variables de TouchWall
    private ContactFilter2D _contactFilter2d = new ContactFilter2D()
    {
        useTriggers = false
    };

    private Collider2D[] _overlapColliders = new Collider2D[2];
}
