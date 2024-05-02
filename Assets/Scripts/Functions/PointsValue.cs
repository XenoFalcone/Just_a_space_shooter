using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsValue : MonoBehaviour
{

    public int pointValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScorePlus()
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.AddScore(pointValue);

    }

    public void ScoreMinus()
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.AddScore(-pointValue);

    }

}
