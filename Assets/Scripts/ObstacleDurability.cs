using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDurability : MonoBehaviour
{
    public int Durability = 10;
    private void Update()
    {
        if (Durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
