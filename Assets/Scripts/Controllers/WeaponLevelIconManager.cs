using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class WeaponLevelIconManager : MonoBehaviour
{

    public GameObject player;
    public Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            Shoot shoot = player.GetComponent<Shoot>();
            Sprite weaponLvlIcon = defaultSprite;

            foreach (var lvl in shoot.ShotLevels)
            {
                if (shoot.shotLevel == lvl.Lvl) {
                    if(lvl.Icon != null)
                    {
                        weaponLvlIcon = lvl.Icon;
                    }
                    
                    break;
                }
            }
            
            GetComponent<Image>().sprite = weaponLvlIcon;
        }
        else
        {
            GetComponent<Image>().sprite = defaultSprite;
        }
    }
}
