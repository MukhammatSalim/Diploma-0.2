using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    ParticleSystem waterSystem;
    GameObject waterBottle;
    private void Start() {
        waterBottle = gameObject.transform.GetChild(0).gameObject;
        waterSystem = waterBottle.transform.GetChild(0).GetComponent<ParticleSystem>();
    }
    private void FixedUpdate()
    {
        if (((transform.rotation.eulerAngles.y > 90) || (transform.rotation.eulerAngles.y < -90)) || ((transform.rotation.eulerAngles.z > 90)||(transform.rotation.eulerAngles.z < -90)))
        {
            PoorWater();
        }else StopWater();

    }
    private void PoorWater(){
        waterSystem.Play();
    }
    void StopWater(){
        waterSystem.Stop();
    }
}
