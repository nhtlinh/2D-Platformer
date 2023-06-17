using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int pointsToAdd;
    public float coinDelay;
    public AudioClip coinAudioClip;
    
    //Collision Coin - Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ++score
            ScoreManager.AddPoints(pointsToAdd);
            // sound coin
            //GetComponent<AudioSource>().Play();
            //AudioController.instance.PlayAudio(coinAudioClip);
            AudioSource.PlayClipAtPoint(coinAudioClip, transform.position);
            //Coin Delay
            //StartCoroutine("Delay");
            // destroy coin
            Destroy(gameObject);

        }
    }

    //Delay(coin)
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(coinDelay);
       
    }
}
