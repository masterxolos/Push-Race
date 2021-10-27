﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;
        if (!isShoot)
            DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
    }
    
    private void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
        Debug.Log(mouseReleasePos-mousePressDownPos);
//        gameObject.GetComponent<StickmanControllerEnemy>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    [SerializeField] private float forceMultiplier = 3;
    void Shoot(Vector3 Force)
    {
        if(isShoot)    
            return;
        
        rb.AddForce(new Vector3(Force.x,Force.y,Force.y) * forceMultiplier);
        isShoot = true;
        Spawner.Instance.NewSpawnRequest();
    }
    
}