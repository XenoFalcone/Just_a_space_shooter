using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class shotLevel
{
    public int Lvl;
    public Transform[] Cannons;
    public GameObject ShotPrefab;
    public Sprite Icon;
}

public class Shoot : MonoBehaviour
{

    [Tooltip("Time between two ball")]
    [Range(0.2f, 5f)]
    public float shotInterval;
    public int shotLevel = 1;
    public shotLevel[] ShotLevels;
    public AudioSource ShotSound;
    public string[] tagsForPowerUp;

    private float chrono = 0f;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            chrono += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (tagsForPowerUp.Contains(collision.tag))
        {
            
            if (shotLevel < ShotLevels.Length)
            {
                shotLevel++;
            }
            else
            {
                collision.GetComponent<PointsValue>().ScorePlus();
            }

        }
    }

    public void Shooting()
    {
        if (canShoot && Time.deltaTime > 0)
        {
            //Je créer une balle toutes les X secondes

            //On parcours les niveaux de tirs paramétrés
            foreach (shotLevel SL in ShotLevels)
            {

                //On cherche le niveau de tir actuel
                if (SL.Lvl == shotLevel)
                {
                    //On instancie un tir pour chaque Cannon du niveau de tir
                    foreach (Transform TR in SL.Cannons)
                    {
                        Instantiate(SL.ShotPrefab, new Vector2(TR.position.x, TR.position.y), TR.rotation);
                    }

                }


            }

            if (ShotSound != null)
            {
                ShotSound.Play();
            }
            

            canShoot = false;

        }


        if (chrono >= shotInterval)
        {
            canShoot = true;
            chrono = 0f;
        }
    }

    public void LevelDown()
    {
        if(shotLevel > 1)
        {
            shotLevel--;
        }
    }
}
