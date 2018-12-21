using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titus : CharStats
{
    readonly int charid = 2;
    List<GameObject> moblist;
    CharStats mobStats;
    public Titus()
    {
        Health = 150;
        Energy = 80;
        Strength = 120;
        Defense = 90;
        Agility = 80;
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

