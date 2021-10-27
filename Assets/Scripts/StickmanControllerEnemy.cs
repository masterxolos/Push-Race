using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanControllerEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 2f;
    private Transform target;
    private bool shouldGo;
    private bool isFound;
    private bool isFirstEnemyObject = false;
    [SerializeField] private GameObject box;
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
            box.GetComponent<AddForce>().RemoveVelocity();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            box = other.transform.GetChild(0).gameObject;
            gameObject.transform.gameObject.transform.parent = box.transform;
            if (box.GetComponent<QueueCheck>().firstEnemy == null)
            {
                box.GetComponent<QueueCheck>().firstEnemy = gameObject;
                target = box.GetComponent<QueueCheck>().enemyLocation[0].transform;
                isFirstEnemyObject = true;
            }
            else
            {
                target = box.GetComponent<QueueCheck>().enemyLocation[0].transform;
            }
            shouldGo = true;
            isFound = true;
            animator.SetBool("run", true);
        }
        else if (other.gameObject.CompareTag("enemyStop"))
        {
            gameObject.transform.parent.GetComponent<AddForce>().SetVelocityZero();
            gameObject.GetComponent<Animator>().SetBool("dance", true);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isFirstEnemyObject)
            {
                Destroy(other.gameObject);
                gameObject.transform.parent.GetComponent<AddForce>().RemoveVelocity();
                MakeItBigger();
            }   
        }
    }
    private void MakeItBigger()
    {
        gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
    
}
