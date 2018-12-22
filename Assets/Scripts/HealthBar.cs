using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text Hitpoints;
    int hp;
    public GameObject character;
    private void Update()
    {
        hp = character.GetComponent<CharStats>().HP;
        Hitpoints.text = "" + hp + "";
    }
    
}
