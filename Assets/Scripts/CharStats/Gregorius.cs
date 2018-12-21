using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gregorius : CharStats
{
    readonly int charid = 1;
    List<GameObject> moblist;
    CharStats mobStats;
    public Gregorius()
    {
        Health = 100;
        Energy = 100;
        Strength = 100;
        Defense = 100;
        Agility = 100;
        playercontrol = true;
        
        Movement = Movenum(Agility);
        HP = Health;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Application.Quit();
        }
    }
}
