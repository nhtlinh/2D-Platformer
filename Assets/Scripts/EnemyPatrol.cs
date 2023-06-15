using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;
    Rigidbody2D m_rb;

    //Wall Check
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    bool m_hittingWall;

    //Edge Check
    public Transform edgeCheck;
    bool m_notAtEdge;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Wall Check
        m_hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        //Edge Check
        m_notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (m_hittingWall || !m_notAtEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            //Wallcheck - left
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //move right
            m_rb.velocity = new Vector2(moveSpeed, m_rb.velocity.y);
        }
        else
        {
            //Wallcheck - right
            transform.localScale = new Vector3(1f, 1f, 1f);
            //move left
            m_rb.velocity = new Vector2(-moveSpeed, -m_rb.velocity.y);
        }
    }
}
