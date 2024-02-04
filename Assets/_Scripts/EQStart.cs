using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQStart : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    // Start is called before the first frame update
   public void OnEQActivation()
    {
        _rb.useGravity = true;
    }
}
