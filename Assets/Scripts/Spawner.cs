using System;
using System.Collections;
using System.Collections.Generic;
using Tabtale.TTPlugins;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 SpawnPos;
    [SerializeField] private GameObject SpawnObject;

    [SerializeField] private float spawnDurationInSeconds = 1;

    #region Singleton

    public static Spawner Instance;

    private void Awake()
    {
        // Initialize CLIK Plugin
        TTPCore.Setup();
        // Your code here
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
        Instantiate(SpawnObject, SpawnPos, Quaternion.identity);
    }

    public void NewSpawnRequest()
    {
        Invoke("SpawnNewObject",spawnDurationInSeconds);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
