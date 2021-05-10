using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 800;


    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private bool facingRight;



    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isGrounded = true;


    }

    // Update is called once per frame
    void Update()
    {
        float xDisplacement = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        {
            float speed = 3;
            if (Input.GetKey(KeyCode.LeftShift)) speed = 8;
            var y = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(y, 0, 0);
            transform.Translate(0, 0, z);
        }

    }




    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);


    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = col.transform;
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = null;
        isGrounded = true;
    }

}
