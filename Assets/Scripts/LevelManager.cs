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

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
        yield return new WaitForSeconds(respawnDelay);
        //Effect respawn
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        //Show
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        //Position
        player.transform.position = currentCheckpoint.transform.position;
    }
}
