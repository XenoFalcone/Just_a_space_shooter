using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpwanerController : MonoBehaviour
{


    public float spawnInterval;
    public GameObject turret;

    [SerializeField] private float chrono = 0f;
    [SerializeField] private bool chronoStart = false;
    private Animator a;


    private void Awake()
    {
        a = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!chronoStart)
        {
            if(GetComponentsInChildren<Transform>().Length == 1)
            {
                chronoStart = true;
            }
        }
        else
        {
            chrono += Time.deltaTime;

            if (chrono >= spawnInterval)
            {

                if (a != null)
                {
                    a.SetBool("Spawning", true);
                }

                Instantiate(turret, this.transform);
                chrono = 0f;
                chronoStart = false;
            } 

        }
    }
}
