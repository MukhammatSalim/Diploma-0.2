using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherController : MonoBehaviour
{
    public bool IsPinOut;
    public GameObject WaterPoint;
    [SerializeField] private XRGrabInteractable _pinXR;
    [SerializeField] private Rigidbody _pinrb;
    public Collider PinPlace;

    public void StartSpray(){
        if (IsPinOut){
            WaterPoint.SetActive(true);
        }
    }

    public void StopSpray(){
        WaterPoint.SetActive(false);
    }

    public void RemovePin(){
        IsPinOut = true;
        _pinXR.retainTransformParent = false;
        _pinrb.useGravity = true;
        _pinrb.isKinematic = false;
    }
    private void OnTriggerExit(Collider other) {
        RemovePin();
    }
}
