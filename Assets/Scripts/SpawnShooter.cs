using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShooter : MonoBehaviour
{
    [SerializeField] private float flightDurationInSeconds = 1;

    private Spawn _currentSpawn;

    private Camera _Maincamera;

    private bool _isShot;
    // Start is called before the first frame update
    void Start()
    {
        _Maincamera = Camera.main;
    }

    public void ChangeCurrentSpawn(Spawn NewSpawn)
    {
        _currentSpawn = NewSpawn;
        _isShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isShot)
            {
                return;
            }

            RaycastHit hit;
            Ray ray = _Maincamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                ShootWithVelocity(hit.point);
            }
        }
    }

    private void ShootWithVelocity(Vector3 TargetPosition)
    {
        
        _currentSpawn.MoveWithVelocity(TargetPosition - _currentSpawn.transform.position / flightDurationInSeconds);
        _isShot = true;
    }
}
