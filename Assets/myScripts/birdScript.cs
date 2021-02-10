using UnityEngine;
using System.Collections;

public class birdScript : MonoBehaviour 
{
	public float upForce = 200f;
	public int lives = 2;
	private bool isDead = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	public AudioClip gameOverSound;
	public AudioClip flapSound;
    public AudioSource audioSource;
	private bool played = false;
	private SpriteRenderer mySprite;
	private BoxCollider2D myCol;

	void Start()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
		mySprite = GetComponent<SpriteRenderer>();
		myCol = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		if (!isDead) 
		{
			if (Input.GetButtonDown("FLAP")) 
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
		if (other.gameObject.tag == "column") {
			lives -= 1;

			if (lives <= 0) {
				rb2d.velocity = Vector2.zero;
				isDead = true;
				anim.SetTrigger ("myDie");
				if (!played) {
					audioSource.PlayOneShot(gameOverSound, 1.0f);
					played = true;
				}
				gameControllerScript.instance.BirdDied();
			}
			else {
				myCol.enabled = false;
				mySprite.color = new Color(1,0,0,0.5f);
				StartCoroutine(enableBox(1.5F));
			}
		}
		else {
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

	IEnumerator enableBox(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		myCol.enabled = true;
		mySprite.color = new Color(1,1,1,1);
	}
}
