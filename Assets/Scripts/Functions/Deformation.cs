using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deformation : MonoBehaviour
{

    public int tour = 4;
    public float waitTime = 4f;
    public Coroutine maFonction;
    public bool Stop = false;
    
    // Start is called before the first frame update
    void Start()
    {
        maFonction = StartCoroutine(Deform());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Deform()
    {
        //transform.position : position dans le monde
        //transform.localPosition : position par rapport au parent
        //transform.parent = null


        int i = 1;

        while (i <= tour)
        {

            i++;

            yield return new WaitForSeconds(waitTime);
            transform.localScale = new Vector3(i, i, i);

            yield return new WaitForSeconds(waitTime);
            transform.localScale = new Vector3(i-1, i-1, i-1);


 
        }

       
    }
}
