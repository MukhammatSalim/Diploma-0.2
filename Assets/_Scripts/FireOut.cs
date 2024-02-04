/*
    This script is placed on the fire particle.
    It controls the fire extinguishing rate by reducing the emission each time a 'Water' particle collides with it.
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FireOut : MonoBehaviour {
    private ParticleSystem fireParticles;
    private ParticleSystem.EmissionModule fireEmission;
    private bool notFound = false;
    private float currentEmission = 0;
    [SerializeField] private float fadeRate = 1;
    public GameManager GameManager;

    // Use this for initialization
    void Start()
    {
        // Get Particle System and emission
        if (GetComponent<ParticleSystem>())
        {
            fireParticles = GetComponent<ParticleSystem>();
            fireEmission = fireParticles.emission;
            currentEmission = fireEmission.rateOverTime.constant;
        }
        else
        {
            Debug.Log("ERROR :: FireOut - Particle System not found on object: " + gameObject.name);
            notFound = true;
        }
    }
	
	void Update () {
        // if no particle system, do nothing
        if (notFound)
            return;
        // check if fire is extinguished
        
	}

 void OnCollisionEnter(Collision other) {
    if (currentEmission > 0){
        if (other.transform.tag == "Water")
        {
            currentEmission -= fadeRate;
            fireEmission.rateOverTime = currentEmission;
            if (currentEmission <= 0)
            {
            fireParticles.Stop();
            GameManager.ChangeNumberOfFires();

            }
        }
        }
}
    private void OnParticleCollision(GameObject other)
    {
        // if fire got wet decrease emission rate
        if (currentEmission > 0){
        if (other.tag == "Water")
        {
            currentEmission -= fadeRate;
            fireEmission.rateOverTime = currentEmission;
            if (currentEmission <= 0)
            {
            fireParticles.Stop();
            GameManager.ChangeNumberOfFires();

            }
        }
        }
    }
}
