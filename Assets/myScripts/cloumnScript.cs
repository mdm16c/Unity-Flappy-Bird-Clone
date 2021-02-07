using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloumnScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<birdScript>() != null)
		{
			gameControllerScript.instance.BirdScored();
		}
	}

	private void Update() {
		if(gameObject.tag == "temp" && gameObject.transform.position.x < -10) {
			Destroy(gameObject);
		}
	}
}
