using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public PlayerController player;

    //Particle Effects
    public GameObject deathParticle;
    public GameObject respawnParticle;

    //Delay Respawn Player
    public float respawnDelay;

    //Score when player death
    public int pointPenaltyOnDeath;

    //Fixing Gravity (Effect vision)
    float m_gravityStore;

    //Camera following
    CameraController m_camera;

    //Health Player
    public HealthManager healthManager;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        m_camera = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if catch collision player with spikes -> return position checkpoint
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        //Effect death
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        //Disappear
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        //Camera following
        m_camera.isFollowing = false;
        //Score on Death
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        //Fixing Gravity (Effect vision) - Death
            //m_gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
            //player.GetComponent <Rigidbody2D>().gravityScale = 0f;
        //Player fall pause
            //player.GetComponent <Rigidbody2D>().velocity = Vector2.zero;
        //Delay between death with respawn
        yield return new WaitForSeconds(respawnDelay);
        //Fixing Gravity (Effect vision) - Spawn
            //player.GetComponent<Rigidbody2D>().gravityScale = m_gravityStore;
        //Position
        player.transform.position = currentCheckpoint.transform.position;
        //Knockback (spawn not jump)
        player.knockBackCount = 0;
        //Show
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        //Camera following
        m_camera.isFollowing = true;
        //Health player full
        healthManager.FullHealth();
        healthManager.isDead = false;
        //Effect respawn
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
