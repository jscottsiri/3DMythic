using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    readonly int ScrollSpeed = 7;
    public Transform target;
	// Use this for initialization
	void Start () {

    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x >= Screen.width * 0.95)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed);
            }
            else if (Input.mousePosition.x <= Screen.width * 0.05)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.left * Time.deltaTime * ScrollSpeed);
            }
            if (Input.mousePosition.y <= Screen.height * 0.05)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.down * Time.deltaTime * ScrollSpeed);
            }
            else if (Input.mousePosition.y >= Screen.height * 0.95)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.up * Time.deltaTime * ScrollSpeed);
            }
        }
    }

}
