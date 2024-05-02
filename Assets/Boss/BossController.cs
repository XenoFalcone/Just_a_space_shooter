using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public float MoveSpeed = 1f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("BossPosition").transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed*Time.deltaTime);
    }

    public void BossDetsroyed()
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.BossDestroyed = true;
    }
}
