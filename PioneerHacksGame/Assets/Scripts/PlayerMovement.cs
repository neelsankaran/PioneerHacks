using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float hoverStrength;
    public float offSetFromZero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x,(Mathf.Sin(Time.time)*hoverStrength)+offSetFromZero,transform.position.z);
    }
}
