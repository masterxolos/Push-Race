using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShootEnemy : MonoBehaviour
{
    private Rigidbody rb;
    private bool isShoot;
    [SerializeField] private float forceMultiplier = 3;
    private Vector3[] EnemyFireLocations = new Vector3[6];
    private int index = 0;
    [SerializeField] private float shootDelay = 4f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EnemyFireLocations[0] = new Vector3(67.9f, -246f, 0);
        EnemyFireLocations[1] = new Vector3(-33.9f, 152f, 0);
        EnemyFireLocations[2] = new Vector3(-42.4f, 174.8f, 0);
        EnemyFireLocations[3] = new Vector3(25.5f, 118.8f, 0);
        EnemyFireLocations[4] = new Vector3(72.1f, 140.3f, 0);


        StartCoroutine(wait());
    }

    void Shoot(Vector3 Force)
    {
        Debug.Log(Force);
        if(isShoot)    
            return;
        var a = Random.Range(1, 8);
        Debug.Log(a);
        switch (a)
        {
            case 1:
                rb.AddForce(new Vector3(67.9f,60,Force.y) * forceMultiplier);
                break;
            case 2:
                rb.AddForce(new Vector3(0,20,Force.y) * forceMultiplier);
                break;
            case 3:
                rb.AddForce(new Vector3(-130,50,Force.y) * forceMultiplier);
                break;
            case 4:
                rb.AddForce(new Vector3(-60,20,Force.y) * forceMultiplier);
                break;
            case 5:
                rb.AddForce(new Vector3(-60,0,Force.y) * forceMultiplier);
                break;
            case 6:
                rb.AddForce(new Vector3(40,-10,Force.y) * forceMultiplier);
                break;
            case 7:
                rb.AddForce(new Vector3(-110,30,Force.y) * forceMultiplier);
                break;
        }
        
        isShoot = true;
        EnemySpawner.Instance.NewSpawnRequest();
       // gameObject.GetComponent<StickmanControllerEnemy>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.tag = "Enemy";
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(shootDelay);
        Shoot(EnemyFireLocations[index]);
    }
}
