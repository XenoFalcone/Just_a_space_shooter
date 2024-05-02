using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Shoot))]
[RequireComponent(typeof(HPModifier))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(PointsValue))]
[RequireComponent(typeof(Drops))]

public class EnnemyController : MonoBehaviour
{

    [SerializeField] private UnityEvent OnShoot = new UnityEvent();
    [SerializeField] private UnityEvent OnMove = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Gestion du tir
        Vector3 viewport = Camera.main.WorldToViewportPoint(transform.position);
        if ((viewport.x >= 0f && viewport.x <= 1f) && (viewport.y >= 0f && viewport.y <= 1f))
        {
            OnShoot.Invoke();
        }

        //Gestion du movement
        GetComponent<Movement>().Move();
        GetComponent<Movement>().Rotate();
    }

    public void AddDestroyShip() 
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.AddDestroy();
    }
}
