using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using static UnityEditor.Timeline.TimelinePlaybackControls;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HPModifier))]
[RequireComponent(typeof(Movement))]


public class BulletController : MonoBehaviour

{
    #region Variables
    [Header("Game Parameters")]
    [Range(0.2f, 10f)]
    public int MoveSpeed;
    [Range(0.2f, 5f)]
    public int LifeTime;

    public UnityEvent OnCollide = new UnityEvent();

    #endregion

    #region
    public void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion du movement
        GetComponent<Movement>().Move(transform.up);
        GetComponent<Movement>().Rotate(transform.up);
    }
    #endregion

    #region Main Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        OnCollide.Invoke();

    }
    #endregion
}
