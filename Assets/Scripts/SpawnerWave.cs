using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyWave
{
    public float time;
    public GameObject[] enemies;
    public bool spawned = false;
}

public class SpawnerWave : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    private float timer = 0f;

    public EnemyWave[] waves;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewport = Camera.main.WorldToViewportPoint( transform.position );

        if ( ( viewport.x >= 0f && viewport.x <= 1f ) && ( viewport.y >= 0f && viewport.y <= 1f ) )
        {
            // Tout ce code est éxécuté si l'objet est vu par la caméra
            timer += Time.deltaTime;

            foreach ( EnemyWave EW in waves )
            {
                if ( !EW.spawned && EW.time <= timer )
                {

                    foreach ( GameObject enemy in EW.enemies )
                    {
                        Instantiate( enemy, transform.position, Quaternion.identity );
                    }

                    EW.spawned = true;
                }
            }
        }

    }
}
