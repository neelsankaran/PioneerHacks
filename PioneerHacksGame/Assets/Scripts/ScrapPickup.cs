using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPickup : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Destroy(this.gameObject);
            other.GetComponent<PlayerAttributes>().addScrap();
        }
    }
}
