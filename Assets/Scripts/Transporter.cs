using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour {

    public Movement movescript;
    public Transform Exit1;
    public Transform Enter1;
    public Transform Exit2;
    public Transform Enter2;
    public Transform chara;
	void Start () {
        chara = movescript.CurrentCharacter.transform;
    }
	

	void Update () {
        chara = movescript.CurrentCharacter.transform;
        teleport();

    }
    void teleport ()
    {
        if (chara.position == Exit1.position)
        {
            chara.position = Enter2.position;
        }
        else if (chara.position == Exit2.position)
        {
            chara.position = Enter1.position;
        }
    }
}
