using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 2f;
    private Transform target;
    private bool shouldGo;
    private bool isFound;
    private GameObject box;
    private bool isFirstObject = false;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (shouldGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }

        if (shouldGo && transform.position == target.position)
        {
            shouldGo = false;
            animator.SetBool("push", true);
            box.GetComponent<AddForce>().AddVelocity();
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            box = other.transform.GetChild(0).gameObject;
            gameObject.transform.gameObject.transform.parent = box.transform;
            if (box.GetComponent<QueueCheck>().firstPlayer == null)
            {
                box.GetComponent<QueueCheck>().firstPlayer = gameObject;
                target = box.GetComponent<QueueCheck>().location[0].transform;
                isFirstObject = true;
            }
            else
            {
                target = box.GetComponent<QueueCheck>().location[0].transform;
            }
            shouldGo = true;
            isFound = true;
            animator.SetBool("run", true);
        }
        else if (other.gameObject.CompareTag("X2"))
        {
            gameObject.tag = "2Player";
            MakeItBigger();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("stop"))
        {
            gameObject.transform.parent.GetComponent<AddForce>().SetVelocityZero();
            gameObject.GetComponent<Animator>().SetBool("dance", true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isFirstObject)
            {
                Destroy(other.gameObject);
                gameObject.transform.parent.GetComponent<AddForce>().AddVelocity();
                MakeItBigger();
            }   
        }
        else if (other.gameObject.CompareTag("2Player"))
        {
            if (isFirstObject)
            {
                Destroy(other.gameObject);
                gameObject.transform.parent.GetComponent<AddForce>().AddVelocity();
                gameObject.transform.parent.GetComponent<AddForce>().AddVelocity();
                MakeItBigger();
                MakeItBigger();
            }   
        }
        
    }
    
    private void MakeItBigger()
    {
        gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
    /*
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 2f;
    private Vector3 target;
    private bool shouldGo;
    private bool isFound;   
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        if (shouldGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }

        if (transform.position == target)
        {
            shouldGo = false;
            animator.SetBool("push", true);
        }
        
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            if (isFound == false)
            {
                var targetGameObject = FindClosestBox().transform.GetChild(0).gameObject;
                //var targetGameObject = FindClosestBox();
                target = targetGameObject.transform.position;
                gameObject.transform.parent = targetGameObject.transform.parent.gameObject.transform;
                Destroy(targetGameObject);
                shouldGo = true;
                isFound = true;
                animator.SetBool("run", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            gameObject.transform.parent = other.gameObject.transform;
        }
    }
    
    
    
    private GameObject FindClosestBox()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("PlayerLocation");
        
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (closest == null)
        {
            
        }
        return closest;
    }
    */
}
