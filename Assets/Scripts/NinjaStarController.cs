using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NinjaStarController : MonoBehaviour
{
    public float speed;
    Rigidbody2D m_rb;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        //Fix firePoint left
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = new Vector2(speed, m_rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
