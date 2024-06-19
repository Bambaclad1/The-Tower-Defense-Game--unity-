using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public float targetTime = 5f;
    public ParticleSystem particleSystem;

    private List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;
        particleSystem.Play();
        if (targetTime < 0f)
        {
            particleSystem.Stop();
        }
        targetTime = 5f;

    }

    private void OnParticleCollision(GameObject other)
    {
        int events = particleSystem.GetCollisionEvents(other, colEvents);
        Debug.Log("IM HIT!");

        for (int i = 0; i < events; i++)
        {
        }
    }
}