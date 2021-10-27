using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddForce : MonoBehaviour
{
    private Transform _transform;
    public Vector3 speedv3 = new Vector3(0, 0, 0);

    [SerializeField] private float speed = 0.2f;

    private List<Rigidbody> _objects = new List<Rigidbody>();

    private bool isStopped;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position += speedv3;
        if (isStopped)
        {
            speedv3 = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddVelocity();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            RemoveVelocity();
        }
    }

    public void AddVelocity()
    {
        speedv3 += new Vector3(0,0,speed);
    }

    public void RemoveVelocity()
    {
        speedv3 += new Vector3(0, 0, -speed);
    }

    public void SetVelocityZero()
    {
        isStopped = true;
    }
}
