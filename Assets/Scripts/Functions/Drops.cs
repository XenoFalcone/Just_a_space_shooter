using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{

    public Drop[] dropList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dropping()
    {
        foreach (var drop in dropList)
        {
            if(Random.value < drop.dropRate)
            {
                Instantiate(drop.dropObject, transform.position, drop.dropObject.transform.rotation);
            }
        }
    }


}

[System.Serializable]
public class Drop
{
    public GameObject dropObject;
    [Range(0f,1f)]
    public float dropRate;
}
