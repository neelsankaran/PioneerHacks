using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    public Camera cam;
	
	// Update is called once per frame
	void Update () {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            this.gameObject.transform.LookAt(hit.point);
        }
    }
}
