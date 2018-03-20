using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collisionScript : MonoBehaviour {

    int coinCont = 0;
    Text textUi;

	// Use this for initialization
	void Start () {
        textUi = FindObjectOfType<Text>();
        textUi.text = 0 + ":_(";
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
        if (other.CompareTag("Coin"))
        {
            coinCont++;
            Destroy(other.gameObject);
            textUi.text = coinCont.ToString();
        }
    }
}
