using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	private Rigidbody2D myBody;
	[SerializeField]
	private float speed = 5f;
	
	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		myBody.velocity = Vector2.down * speed;
		Physics2D.IgnoreLayerCollision(8, 15);
		Physics2D.IgnoreLayerCollision(9, 15);
		Physics2D.IgnoreLayerCollision(10, 15);
		Physics2D.IgnoreLayerCollision(11, 15);
		Physics2D.IgnoreLayerCollision(12, 15);
		Physics2D.IgnoreLayerCollision(14, 15);
	}
}
