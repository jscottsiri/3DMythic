using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrder : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Queue<GameObject> Turn = new Queue<GameObject>();
        GameObject CurrentCharacter = new GameObject();
        GameObject[] Characters = GatherCharacters();
        List<GameObject> CharList = new List<GameObject>();

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
    GameObject GetFastest(List<GameObject> CharList)
    {
        int maxSpeed = 0;
        GameObject fastest = new GameObject();
        foreach(GameObject i in CharList)
        {
            if (i.GetComponent<CharStats>().Agility > maxSpeed)
            {
                maxSpeed = i.GetComponent<CharStats>().Agility;
                fastest = i;
            }
        }

        return fastest;
    }
    void CombatOrder(List<GameObject> CharList, Queue<GameObject> Order)
    {
        List<GameObject> AllCharacters = CharList;
        foreach (GameObject i in AllCharacters)
        {
            Order.Enqueue(GetFastest(CharList));
            CharList.Remove(GetFastest(CharList));
        }
    }
    public void OrderControl(Queue<GameObject> Order, GameObject CurrentCharacter)
    {
        
        if (Order.Count > 0)
        {
            CurrentCharacter = Order.Dequeue();
            Order.Enqueue(CurrentCharacter);
        }
    }
    //void EndConditions(Queue<GameObject> Order, )

}
