using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedPowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    private Rigidbody2D myBody;
	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		myBody.velocity = Vector2.down * speed;
		Physics2D.IgnoreLayerCollision(8, 12);
		Physics2D.IgnoreLayerCollision(9, 12);
		Physics2D.IgnoreLayerCollision(10, 12);
		Physics2D.IgnoreLayerCollision(11, 12);


	}
}
