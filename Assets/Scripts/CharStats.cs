using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {
    protected int Health;
    protected int Energy;
    protected int Strength;
    protected int Defense;
    public int Agility;
    public Movement movescript;
    public bool playercontrol;

    public int HP;
    protected int Movement;
    public int Movenum(int Agility)
    {
        int movement = (Agility / 10);
        return movement;
    }
}
