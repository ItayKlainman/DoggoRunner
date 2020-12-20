using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianStarter : MonoBehaviour
{
    private PedestrianBehaviour behaviour;
    private void Start()
    {
        behaviour = GetComponentInParent<PedestrianBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        behaviour.startWalking = true; 
    }
}
