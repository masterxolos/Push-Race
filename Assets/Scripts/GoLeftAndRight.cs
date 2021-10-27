using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoLeftAndRight : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float second;

    [SerializeField] private Ease _ease;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(onStart());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator onStart()
    {
        while (true)
        {
            gameObject.transform.DOMove(endPosition, second).SetEase(_ease);
            yield return new WaitForSeconds(second);
            gameObject.transform.DOMove(startPosition, second).SetEase(_ease);
            yield return new WaitForSeconds(second);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        gameObject.SetActive(false);
    }
}
