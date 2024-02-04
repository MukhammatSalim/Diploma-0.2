using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private void OnParticleCollision(Collision other) {
        if(other.gameObject.GetComponent<IFire>() != null){
            other.gameObject.GetComponent<IFire>().Extinguish();
            Debug.Log("Extinguished");
        }
    }
}
