using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    bool m_playerInZone;
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        m_playerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && m_playerInZone)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_playerInZone = false;
        }
    }
}
