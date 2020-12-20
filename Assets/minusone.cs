using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minusone : MonoBehaviour
{
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        LeanTween.moveY(gameObject, transform.position.y-20, 0.5f).setOnComplete(DisableUI);
    }
    private void OnEnable()
    {
        LeanTween.moveY(gameObject, transform.position.y - 20, 0.5f).setOnComplete(DisableUI);
    }

    private void DisableUI()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        transform.position = startPos;
    }
}
