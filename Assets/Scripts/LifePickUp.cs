using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour
{
    LifeManager m_lifeManager;

    // Start is called before the first frame update
    void Start()
    {
        m_lifeManager = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_lifeManager.GiveLife();
            Destroy(gameObject);
        }
    }
}
