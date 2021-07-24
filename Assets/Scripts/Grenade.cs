using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float damage = 80f;

    public GameObject explosionEffect;
    
    float countdown;
    bool hasExploded = false;

    public AudioSource explodeVFX;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        explodeVFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded) 
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        if (explodeVFX != null)
        {
            Debug.Log("g sound");
            explodeVFX.Play();
        }

        Debug.Log("BOOM!");

        StartCoroutine(ExplosionEffect());

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders) 
        {
            if (nearbyObject.GetComponent<Target>() != null) {
                nearbyObject.GetComponent<Target>().TakeDamage(damage);
            }
        }
        
        StartCoroutine(RemoveGrenade());
    }

    IEnumerator ExplosionEffect()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    IEnumerator RemoveGrenade()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
