using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPickup : MonoBehaviour {

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("rsgsg");
            GameObject.Destroy(this.gameObject);
            player.GetComponent<PlayerAttributes>().addFuel(20);
        }
    }
}
