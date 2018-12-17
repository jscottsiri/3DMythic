using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharStats {
    protected int Health;
    protected int Energy;
    protected int Strength;
    protected int Defense;
    public int Agility;

    protected int Movement;
    int movenum(int Agility)
    {
        int movement = (Agility / 100);
        return movement;
    }
}
