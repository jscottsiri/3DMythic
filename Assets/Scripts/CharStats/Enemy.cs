using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : CharStats
{
    readonly int charid = 3;
    public Enemy()
    {
        Health = 10;
        Energy = 10;
        Strength = 10;
        Defense = 10;
        Agility = 30;
        playercontrol = false;

        Movement = Movenum(Agility);
        HP = Health;
        bool Action = true;

    }
    private void Update()
    {
        if ((HP <= 0) && (gameObject.name == "Cyril"))
        {
            SceneManager.LoadScene(2);
        }

    }
}
