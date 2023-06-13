using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // move left or right
    public float jumpHeight; // jump
    Rigidbody2D m_rb; // Physic for jump or move

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to Jump
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, jumpHeight); // jump with value Height vector2(0, jumpHeight)
        }

        if (Input.GetKey(KeyCode.D)) // Move to Right
        {
            m_rb.velocity = new Vector2(moveSpeed, m_rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A)) // Move to Left
        {
            m_rb.velocity = new Vector2(-moveSpeed, m_rb.velocity.y);
        }
    }
}
