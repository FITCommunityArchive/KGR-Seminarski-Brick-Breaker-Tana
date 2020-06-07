using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	private Rigidbody2D myBody;
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private GameObject ball;
	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		myBody.velocity = Vector2.down * speed;
		Physics2D.IgnoreLayerCollision(8, 11);
		Physics2D.IgnoreLayerCollision(9, 11);
		Physics2D.IgnoreLayerCollision(10, 11);
		Physics2D.IgnoreLayerCollision(11, 11);
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
		if (target.gameObject.tag == MyTags.Rocket_Tag||target.gameObject.tag==MyTags.ExtendedRocket_Tag)
		{
			SoundManager.instance.PowerUpSoundFX();
			Vector2 temp1, temp2, temp3;
			temp1.x = Random.Range(-10, 10);
			temp1.y = Random.Range(0, 5);
			temp2.x = Random.Range(-10, 10);
			temp2.y = Random.Range(0, 5); 
			temp3.x = Random.Range(-10, 10);
			temp3.y = Random.Range(0, 5);
			GameObject newBall1 = Instantiate(ball, temp1, Quaternion.identity);
			GameObject newBall2 = Instantiate(ball, temp2, Quaternion.identity);
			GameObject newBall3 = Instantiate(ball, temp3, Quaternion.identity);
			newBall1.transform.parent = GameObject.FindGameObjectWithTag("BallParent").transform;
			newBall2.transform.parent = GameObject.FindGameObjectWithTag("BallParent").transform;
			newBall3.transform.parent = GameObject.FindGameObjectWithTag("BallParent").transform; 
			Rigidbody2D newBallBody1 = newBall1.GetComponent<Rigidbody2D>();
			newBallBody1.velocity = Vector2.one * 5f;
			Rigidbody2D newBallBody2 = newBall2.GetComponent<Rigidbody2D>();
			newBallBody2.velocity = Vector2.one * 5f; 
			Rigidbody2D newBallBody3 = newBall3.GetComponent<Rigidbody2D>();
			newBallBody3.velocity = Vector2.one * 5f;
			Destroy(gameObject);
		}
	}
}
