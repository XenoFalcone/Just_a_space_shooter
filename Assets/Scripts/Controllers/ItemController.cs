using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(PointsValue))]

public class ItemController : MonoBehaviour
{

    public UnityEvent OnCollide = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion du movement
        GetComponent<Movement>().Move();
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        OnCollide.Invoke();

    }
}
