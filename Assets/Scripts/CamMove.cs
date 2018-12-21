using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    Vector3 distance;
    float space;
    Transform Hover;
    public Movement movescript;
    // Start is called before the first frame update
    void Start()
    {
        space = 30f;
        Hover = movescript.CurrentCharacter.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (movescript.Moved)
        {
            movescript.Moved = false;
            Hover = movescript.CurrentCharacter.transform;
            distance = new Vector3(Hover.transform.position.x, space, Hover.transform.position.z);
            Camera.main.transform.position = (distance);
        }
    }
}
