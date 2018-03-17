﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    public float hoverStrength;
    public float offSetFromZero;
    public float speed;
    public Camera cam;
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x,(Mathf.Sin(Time.time)*hoverStrength)+offSetFromZero,transform.position.z);
        if (Input.GetMouseButton(0)) { 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.tag.Equals("Interactable"))
                {
                    hitObj.interact();
                }
            }
        }

        /*
        if (Input.GetKeyDown("w"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward*speed);
        }else if (Input.GetKeyDown("s"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.back * speed);
        }
        else if (Input.GetKeyDown("d"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
        }
        else if (Input.GetKeyDown("a"))
        {

        }
        */
    }
}
