using UnityEngine;
using UnityEngine.AI;

public class TruckBehaviour : MonoBehaviour
{
    private NavMeshAgent navAgent;

   [SerializeField] private Transform target;
   [SerializeField] private ParticleSystem vfx;
   [SerializeField] private Transform window;
    
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = target.position;
    }
    private void OnTriggerEnter(Collider other)
    {    
        if(other.gameObject.CompareTag("Drop"))
        {

            Instantiate(vfx, window.position, Quaternion.identity);
            //play sound
        }
    }

}
