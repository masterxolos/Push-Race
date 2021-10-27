using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Vector3 SpawnPos;
    [SerializeField] private GameObject SpawnObject;

    [SerializeField] private float spawnDurationInSeconds = 3;

    

    #region Singleton

    public static EnemySpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = transform.position;
        SpawnNewObject();
    }

    public void SpawnNewObject()
    {
            Instantiate(SpawnObject, SpawnPos, Quaternion.Euler(0,-160,0));
    }

    public void NewSpawnRequest()
    {
        Invoke("SpawnNewObject",spawnDurationInSeconds);
    }

    // Update is called once per frame

}