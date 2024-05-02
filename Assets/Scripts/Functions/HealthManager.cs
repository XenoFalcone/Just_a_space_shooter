using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    #region Variables
    [Header("Game Parameters")]
    [HideInInspector]public int HP = 3;
    public int MaxHP = 3;
    public string[] tagsForDamage;
    public string[] tagsForHeal;

    public UnityEvent OnDestroy = new UnityEvent();
    public UnityEvent OnDamage = new UnityEvent();
    public GameObject ExplosionPrefab;

    private Animator a;
    #endregion

    #region
    public void Awake()
    {
        a = GetComponent<Animator>();
        HP = MaxHP;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }
    #endregion

    #region Main Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (tagsForDamage.Contains(collision.tag))
        {

            HPModifier damageComponent = collision.gameObject.GetComponent<HPModifier>();

            if (a!= null)
            {
                a.SetBool("Damage", true);
            }
            

            if (damageComponent != null)
            {
                HP -= damageComponent.amount;
            }
            else
            {
                HP--;
            }

            OnDamage.Invoke();


            if (HP <= 0f)
            {
                if(ExplosionPrefab  != null)
                {
                    Instantiate(ExplosionPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                }

                Destroy(gameObject);
                OnDestroy.Invoke();
            }

        }
        else if (tagsForHeal.Contains(collision.tag))
        {

            HPModifier healthComponent = collision.gameObject.GetComponent<HPModifier>();

            if (HP < MaxHP)
            {
                HP += healthComponent.amount;
            }else
            {
                collision.GetComponent<PointsValue>().ScorePlus();
            }


        }


    }

    public void Explode()
    {
        if (ExplosionPrefab != null)
        {
            Instantiate(ExplosionPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        }

        Destroy(gameObject);
        OnDestroy.Invoke();
    }

    #endregion
}
