using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    //movement variables
    public float maxSpeed;
    public SpriteRenderer sr;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    public int extraJumpsValue;
    public Transform projectileTip;
    public GameObject bullet;
    public bool isTouchingFront;
    public Transform frontCheck;
    public float wallSlidingSpeed;
    public float CheckRadius = 0.2f;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public GameObject player;

    //player ability toggles
    public bool doubleJumping;
    public bool wallSliding;
    public bool wallJumping;

    //player state variables
    public bool grounded = false;
    public bool canDoubleJump;

    //Private Variables
    private Rigidbody2D myRB;
    private Animator myAnim;
    private float move;
    private float moveUp;
    private readonly float groundCheckRadius = 0.2f;
    private int extraJumps;
    private readonly float FireRate = 0.5f;
    private float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //initialize RB and Anim
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        extraJumps = extraJumpsValue;
    }

    void FixedUpdate()
    {
        //check if we are grounded takes care of falling if not grounded then we are jumping or falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, CheckRadius, groundLayer);
        myAnim.SetBool("isTouchingFront", isTouchingFront);

        //sets the setFloat variable on the y coordinate
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        //determines if player pushed button will give -1 or 1 for back and forth, up and down movement
        move = Input.GetAxis("Horizontal");
        moveUp = Input.GetAxis("Vertical");

        //using absolute value to get a negatie or positive for left right speed
        myAnim.SetFloat("speed", Mathf.Abs(move));

        // moves body depending on max speed
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        //checks to see if you pressed left or right and faces character accordingly
        if (move > 0)
        {
            //sr.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (move < 0)
        {
            //sr.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //Grounded State
        if (grounded == true)
        {
            extraJumps = extraJumpsValue;
            doubleJumping = false;
        }

        if ((isTouchingFront) && !grounded && move != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        SetAnimator();

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded == true)
            {
                Jump();
                grounded = false;
                doubleJumping = false;
            }

            if (extraJumps > 0 && !wallSliding)
            {
                if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
                {
                    grounded = true;
                    Jump();
                    doubleJumping = true;
                    extraJumps--;
                }

                canDoubleJump = true;
            }
            else
            {
                canDoubleJump = false;
            }
        }

        //wallSliding

        if (wallSliding)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, Mathf.Clamp(myRB.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        //wallJump code
        if (Input.GetKeyDown(KeyCode.Space) && wallSliding)
        {
            wallJumping = true;
            //delays setting wall jump to false without coroutine
            Invoke("SetWallJumpingFalse", wallJumpTime);
        }

        if (wallJumping)
        {
            myRB.velocity = new Vector2(xWallForce * -move, yWallForce);

        }

        //player shooting fire with left click (Fireball code)
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + FireRate;
                if (sr.flipX == false)
                {
                    Instantiate(bullet, projectileTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else if (sr.flipX == true)
                {
                    Instantiate(bullet, projectileTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                }
            }
        }
    }

    /**public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = null;
        }
    }**/

    public void Jump()
    {
        myRB.velocity = new Vector2(myRB.velocity.x, 0);
        myRB.velocity = Vector2.up * jumpHeight;
    }

    public void TouchedJumpOrb()
    {
        Jump();
    }

    private void SetAnimator()
    {
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetBool("canDoubleJump", canDoubleJump);
        myAnim.SetBool("wallSliding", wallSliding);
        myAnim.SetBool("isTouchingFront", isTouchingFront);
        myAnim.SetBool("doubleJumping", doubleJumping);
        myAnim.SetBool("wallJumping", wallJumping);
    }

    private void SetWallJumpingFalse()
    {
        wallJumping = false;
    }
}
