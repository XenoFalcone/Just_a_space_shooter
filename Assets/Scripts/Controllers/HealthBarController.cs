using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class HealthBarController : MonoBehaviour
{

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float playerLife = player.GetComponent<HealthManager>().HP;
            GetComponent<Image>().fillAmount = playerLife / 6;
        }
        else
        {
            GetComponent<Image>().fillAmount = 0;
        }
           
        

    }
}
