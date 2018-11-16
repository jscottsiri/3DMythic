using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Transform mover;
    public Transform location;
    public GameObject Target;

    void Update()
    {
        if ((mover.position.x != location.position.x) || (mover.position.y != location.position.y) )
        {
            StartCoroutine(delay(2.0f));
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Target.transform.position = hit.point;
            }
        }
    }
    public static void move(Transform character, Transform location)
    {
        character.position = location.position;
    }
    IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        move(mover, location);
    }
}
