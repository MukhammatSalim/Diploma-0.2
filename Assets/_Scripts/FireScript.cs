using UnityEngine;

public interface IFire
{
    void Extinguish();
}
public class FireScript : MonoBehaviour, IFire
{
    new ParticleSystem particleSystem;
    ParticleSystem.EmissionModule fireEmission;
    SphereCollider sphereCollider;
    float fadeRate = 1f;
    float currentEmission;
    GameManager gameManager;



    
    private void Start()
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
        fireEmission = particleSystem.emission;
        currentEmission = fireEmission.rateOverTime.constant;
    }
    public void Extinguish()
    {
        currentEmission -= fadeRate;
        fireEmission.rateOverTime = currentEmission;
        if (currentEmission <= 0)
        {
            particleSystem.Stop();
            gameManager.ChangeNumberOfFires();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Water"){
            Extinguish();
        }
    }

}
