using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // move left or right
    public float jumpHeight; // jump
    Rigidbody2D m_rb; // Physic for jump or move

    //Finding the Ground
    bool m_grounded;
    //DoubleJumped
    bool m_doubleJumped;
    //Animator
    Animator m_anim;
    //Move speed
    float m_moveVelocity;
    //NinjaStar
    public Transform firePoint;
    public GameObject ninjaStar;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_grounded)
        {
            m_doubleJumped = false;
        }

        //Animation Jump
        m_anim.SetBool("Grounded", m_grounded);
        
        //DoubleJumped
        if (Input.GetKeyDown(KeyCode.Space) && !m_grounded && !m_doubleJumped)
        {
            Jump(); // jump with value Height vector2(0, jumpHeight)
            m_doubleJumped = true;
            m_grounded = false;
        }


        //Finding the Ground - Catch collision with Tag: Ground
        if (Input.GetKeyDown(KeyCode.Space) && m_grounded) // Press Space to Jump
        {
            Jump(); // jump with value Height vector2(0, jumpHeight)
            m_grounded = false; // Player is Jumping
        }

        //Move Speed
        m_moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D)) // Move to Right
        {
            m_moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.A)) // Move to Left
        {
            m_moveVelocity = -moveSpeed;
        }

        //Move
        m_rb.velocity = new Vector2(m_moveVelocity, m_rb.velocity.y);

        //Animation Move
        m_anim.SetFloat("Speed", Mathf.Abs(m_rb.velocity.x));

        //Animation Flip Left or Right
        if (m_rb.velocity.x > 0) // Right
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (m_rb.velocity.x < 0) // Left
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        //NinjaStar
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
        }
    }

    private void Jump()
    {
        m_rb.velocity = new Vector2(m_rb.velocity.x, jumpHeight); // jump with value Height vector2(0, jumpHeight)
    }

    //Finding the Ground - Catch collision with Tag: Ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
             m_grounded = true; // Player is on ground
        }
    }
}
