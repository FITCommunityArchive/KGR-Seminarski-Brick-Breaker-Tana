using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
	[SerializeField]
	private float speed = 4f;
	private Rigidbody2D myBody;
	private Text lifeText;
	public static int broj = 0;
	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		myBody.velocity = Vector2.down * speed;
		Physics2D.IgnoreLayerCollision(8, 10);
		Physics2D.IgnoreLayerCollision(9, 10);
		Physics2D.IgnoreLayerCollision(10, 10);

	}
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == MyTags.BottomBorder_Tag)
		{
			Debug.Log("Border");
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == MyTags.Rocket_Tag || target.gameObject.tag == MyTags.ExtendedRocket_Tag)
		{
			SoundManager.instance.PowerUpSoundFX();
			Destroy(gameObject);
		}
	}
	
}
