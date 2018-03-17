using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    public float hoverStrength;
    public float offSetFromZero;
    public float speed;
    public float accel;
    public Camera cam;
    public NavMeshAgent agent;
    public ParticleSystem destination;
    private bool mouseDown = false;
    private Vector3 emmitPos;
    private ParticleSystem currentParticleSystem;

	// Use this for initialization
	void Start () {
        GameObject.Instantiate(destination);
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(transform.position.x,(Mathf.Sin(Time.time)*hoverStrength)+offSetFromZero,transform.position.z);
        
        if (Input.GetMouseButton(0)) { 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) && mouseDown == false)
            {
                if (currentParticleSystem != null)
                {
                    GameObject.Destroy(currentParticleSystem.gameObject);
                }
                agent.SetDestination(hit.point);
                emmitPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                destination.transform.position = emmitPos;
                currentParticleSystem = GameObject.Instantiate(destination);
                mouseDown = true;
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.tag.Equals("Interactable"))
                {
                    hitObj.interact();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
            mouseDown = false;

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
