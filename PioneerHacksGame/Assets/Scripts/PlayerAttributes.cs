using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {
    private float fuel = 10;
    private float nextUpdate = 1;
    private float scrap = 0;
    public ParticleSystem burner;

    public Text scoreText;
    public Text gameOverText;
    public Text numCollected;

	// Use this for initialization
	void Start () {
        gameOverText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextUpdate)
        {
            //Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            fuel--;
            if (fuel == 0)
            {
                gameOver();
            }

        }
        scoreText.text = "Fuel: " + fuel;
    }

    public void addFuel(float amountAdded)
    {
        fuel += amountAdded;
    }

    public void gameOver()
    {
        gameOverText.text = "Fuel Depleted";
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        GameObject.Destroy(burner.gameObject);
        this.enabled = false;
        gameOverText.gameObject.SetActive(true);
    }

    public void gameWin()
    {
        gameOverText.text = "All Scrap Collected";
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        GameObject.Destroy(burner.gameObject);
        this.enabled = false;
        gameOverText.gameObject.SetActive(true);
    }

    public void addScrap()
    {
        scrap++;
        numCollected.text = "Scrap collected: " + scrap + "/3";
        if (scrap == 3)
        {
            gameWin();
        }
    }
}
