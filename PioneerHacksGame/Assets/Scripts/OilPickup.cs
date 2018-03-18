using UnityEngine;

public class OilPickup : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Destroy(this.gameObject);
            other.GetComponent<PlayerAttributes>().addFuel(20);
        }
    }
}
