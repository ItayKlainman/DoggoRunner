using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public GameObject first, second, third;
    [SerializeField] private float time = 2.5f;
    void Start()
    {
        LeanTween.moveY(first, 100, time).setEaseOutBack().setOnComplete(DestroyFirstPhase);

    }
    private void DestroyFirstPhase()
    {
        LeanTween.moveY(first, -1500, time).setDestroyOnComplete(true);
        LeanTween.moveY(second, 500, time).setEaseOutBack().setOnComplete(DestroySecond);
    }

    private void DestroySecond()
    {
        LeanTween.moveY(second, -1500, time).setDestroyOnComplete(true);
        LeanTween.moveY(third, 750, time).setEaseOutBack().setOnComplete(DestroyThird);
    }
    
  private void DestroyThird()
    {
        LeanTween.moveY(third, -1500, time).setDestroyOnComplete(true);

    }

}
