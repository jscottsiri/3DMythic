using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Queue<GameObject> Turn = new Queue<GameObject>();
        GameObject[] Characters = GatherCharacters();
        List<GameObject> CharList = new List<GameObject>();
        foreach(GameObject i in Characters)
        {
            CharList.Add(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
    GameObject[] GatherCharacters()
    {
        GameObject[] Characters = GameObject.FindGameObjectsWithTag("Character");
        return Characters;
    }
    GameObject InitiativeSort(List<GameObject> CharList)
    {
        int maxSpeed = 0;
        GameObject fastest;
        foreach(GameObject i in CharList)
        {
            if (i.GetComponent<CharStats>.Agility > maxSpeed)
            {
                maxSpeed = i.GetComponent<CharStats>.Agility;
                fastest = i;
            }
        }
    }

}
