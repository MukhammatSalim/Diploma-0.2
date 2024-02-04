using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PinManager : MonoBehaviour
{
    public bool IsPinremoved;
    [SerializeField] private XRGrabInteractable _pinXR;
    [SerializeField] private GameObject _pin;
    [SerializeField] private Rigidbody _pinrb;

    private void Start() {
        _pinXR = _pin.GetComponent<XRGrabInteractable>();
        _pinrb = _pin.GetComponent<Rigidbody>();
    }

    public void Pinremoval(){
        IsPinremoved = true;
        _pinXR.retainTransformParent = false;
        _pinrb.useGravity = true;
        _pinrb.isKinematic = false;
        }

}
