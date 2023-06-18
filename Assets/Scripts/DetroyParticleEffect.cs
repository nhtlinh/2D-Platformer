using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyParticleEffect : MonoBehaviour
{
    public ParticleSystem parSys;

    // Start is called before the first frame update
    void Start()
    {
        parSys = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parSys.isPlaying) return;
        Destroy(gameObject);
    }
}
