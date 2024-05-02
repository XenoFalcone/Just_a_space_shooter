using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Shoot))]
[RequireComponent(typeof(HPModifier))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(Movement))]

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Game Parameters")]


    [Header("Movement Manager")]
    public int MoveSpeed;

    public UnityEvent OnShoot = new UnityEvent();


    private Rigidbody2D _rb2d;
    private bool isShooting;


    #endregion


    #region Unity LifeCycle
    public void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
           
            OnShoot.Invoke();
        }

    }
    #endregion


    #region Main Methods

   

    public void Move(InputAction.CallbackContext context)
    {

        GetComponent<Movement>().Move(context.ReadValue<Vector2>());
        
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        //Debug.Log("Rotate !");

        Vector2 stick = context.ReadValue<Vector2>();

        if(stick.magnitude > 0f)
        {
            //Quaternion lookAt = Quaternion.LookRotation(context.ReadValue<Vector2>(), Vector3.back);
            //_rb2d.SetRotation(lookAt);
            GetComponent<Movement>().Rotate(context.ReadValue<Vector2>());
        }

        

        //Debug.Log(context.ReadValue<Vector2>());
    }

    public void MouseRotate( InputAction.CallbackContext context)
    {
        Vector2 stick = context.ReadValue<Vector2>();

        Vector3 lookPoint = Camera.main.ScreenToWorldPoint(stick) - transform.position;
        lookPoint.z = 0f;

        if (stick.magnitude > 0f)
        {

            GetComponent<Movement>().Rotate(lookPoint);
            /*Quaternion lookAt = Quaternion.LookRotation(lookPoint, Vector3.back);
            _rb2d.SetRotation(lookAt);*/
        }

    }

    public void Shoot(InputAction.CallbackContext context)
    {
        //Debug.Log("Shoot !");
        switch (context.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                //Debug.Log("Shoot commencé!");
                break;
            case InputActionPhase.Performed:
                //Debug.Log("Shoot en cours !");
                isShooting = true;
                break;
            case InputActionPhase.Canceled:
                //Debug.Log("Shoot terminé !");
                isShooting = false;
                break;
            default:
                break;
        }
    }

    #endregion
}
