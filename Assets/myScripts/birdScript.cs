using UnityEngine;
using System.Collections;

public class birdScript : MonoBehaviour 
{
	public float upForce = 200f;
	private bool isDead = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	public AudioClip gameOverSound;
	public AudioClip flapSound;
    public AudioSource audioSource;
	private bool played = false;

	void Start()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (!isDead) 
		{
			if (Input.GetMouseButtonDown(0)) 
			{
				anim.SetTrigger("myFlap");
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, upForce));
				audioSource.PlayOneShot(flapSound, 0.7f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("myDie");
		if (!played) {
			audioSource.PlayOneShot(gameOverSound, 1.0f);
			played = true;
		}
		gameControllerScript.instance.BirdDied();
	}
}
