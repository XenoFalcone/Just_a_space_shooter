using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour

{

    public float ExplosionDuration;

    private float chrono;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, ExplosionDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
