using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //elementos publicos
    [Header("VARIABLES MODIFICABLES")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpSpeed;
    
    public LayerMask layerGround;
    public bool canMove;

    //valores privados
    float moveSpeed;
    float h;
    float v;
    bool isGrounded;
    bool isJumping;
    bool isCrouched;
    bool running;

    //Elementos publicos
    public BoxCollider2D feetPos;

    //elementos privados
    Rigidbody2D rb;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        Animations();
    }

    private void FixedUpdate()
    {
        Movement();
        CheckGround();
        Jump();
    }

    void InputManager()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //input correr
        if (Input.GetButton("Run") && h != 0)
            running = true;
        else if (Input.GetButtonUp("Run") || h == 0)
            running = false;

        //input de salto
        if (Input.GetButtonDown("Jump") && isGrounded && canMove && !isCrouched)
        {
            isJumping = true;
        }

        //input agachado
        if(v < 0 && isGrounded)
            isCrouched = true;
        else if(v >= 0)
            isCrouched = false;
    }

    void Movement()
    {
        if(canMove && !isCrouched)
        {
            rb.velocity = new Vector2(h * moveSpeed * Time.deltaTime, rb.velocity.y);
        }

        if (running)
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }

    void Animations()
    {
        //flip
        if (h > 0 && canMove)
            transform.localScale = new Vector3(1, 1, 1);
        else if(h < 0 && canMove)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetFloat("VelX", Mathf.Abs(rb.velocity.x));

        anim.SetBool("Run", running);
        anim.SetBool("Grounded", isGrounded);

        //animacion de caida
        if(rb.velocity.y < 0 && !isGrounded)
        {
            anim.SetTrigger("Falling");
        }

        //animacion agachado
        anim.SetBool("Crouch", isCrouched);
    }

    void Jump()
    {
        if (isJumping)
        {
            anim.SetTrigger("Jump");
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.IsTouchingLayers(feetPos, layerGround);
    }
}
