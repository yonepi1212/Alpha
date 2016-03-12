using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy : MonoBehaviour
{
    ParticleSystem myParticleSystem;

    void Awake()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
            Destroy(gameObject,0.5f);
    }
}