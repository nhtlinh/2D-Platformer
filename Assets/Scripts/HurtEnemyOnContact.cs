using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour
{
    public int damageToGive;
    public float bounceOnEnemy;
    Rigidbody2D m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            m_rb.velocity = new Vector2(m_rb.velocity.x, bounceOnEnemy);
        }
    }
}
