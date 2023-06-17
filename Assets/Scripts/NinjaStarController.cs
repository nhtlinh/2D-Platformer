using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    public float speed;
    Rigidbody2D m_rb;
    public PlayerController player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public int pointsForKill;
    //Ninjar Motion
    public float rotationSpeed;
    //Enemy Health
    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        //Fix firePoint left
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = new Vector2(speed, m_rb.velocity.y);
        //Ninjar rotation
        m_rb.angularVelocity = rotationSpeed;
    }

    //Destroy Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);
            //Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            //ScoreManager.AddPoints(pointsForKill);

            collision.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
