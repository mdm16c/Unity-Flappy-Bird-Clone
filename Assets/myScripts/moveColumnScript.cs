using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveColumnScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2 (gameControllerScript.instance.scrollSpeed, 0);
	}

	void Update()
	{
		if(gameControllerScript.instance.gameOver == true)
		{
			rb2d.velocity = Vector2.zero;
		}
	}
}
