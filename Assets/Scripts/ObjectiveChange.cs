using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveChange : MonoBehaviour
{
    public Transform char1;
    public Transform char2;
    public GameObject cube;
    public GameObject opponent;
    public Text missiontext;
    bool made = true;
    void Update()
    {
        
        if ((made)&&((char1.position.x > 301) || (char2.position.x > 301)))
        {
            Instantiate(cube, new Vector3(297, 0, -10), Quaternion.identity);
            Instantiate(cube, new Vector3(300, 0, -10), Quaternion.identity);
            Instantiate(opponent, new Vector3(297, 0, -10), Quaternion.identity);
            Instantiate(opponent, new Vector3(297, 0, 2), Quaternion.identity);

            missiontext.text = "Objective: \nDefeat Cyril";
            made = false;
        }

    }
}
