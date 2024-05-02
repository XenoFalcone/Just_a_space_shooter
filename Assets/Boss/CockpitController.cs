using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CockpitController : MonoBehaviour
{

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject turretSpawner1;
    [SerializeField] private GameObject turretSpawner2;
    [SerializeField] private GameObject turretSpawner3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyShip()
    {
        if(turretSpawner1.GetComponentsInChildren<Transform>().Length == 3)
        {
            turretSpawner1.GetComponentInChildren<HealthManager>().Explode();
        }
        if (turretSpawner2.GetComponentsInChildren<Transform>().Length == 3)
        {
            turretSpawner2.GetComponentInChildren<HealthManager>().Explode();
        }

        if (turretSpawner3.GetComponentsInChildren<Transform>().Length == 3)
        {
            turretSpawner3.GetComponentInChildren<HealthManager>().Explode();
        }

        boss.GetComponent<HealthManager>().Explode();
    }
}
