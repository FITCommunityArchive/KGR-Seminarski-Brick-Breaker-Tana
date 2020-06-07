using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public float speed = 5f;
	private static int count=0;
	private Rigidbody2D myBody;
	private Text lifeText;
	
	private GameObject lifeParent;
	[SerializeField]
	private GameObject life;
	public int lives;
	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		Time.timeScale = 1f;
	}

	void Start()
	{
		lifeText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();
		lifeParent = GameObject.FindGameObjectWithTag("LifeParent").gameObject;
		lives = lifeParent.transform.childCount;
		lifeText.text = $"x{lifeParent.transform.childCount}";
		if (count == 0)
		{
			myBody.velocity = Vector2.down * speed;
			count++;
		}
		
		Physics2D.IgnoreLayerCollision(9, 10);
		Physics2D.IgnoreLayerCollision(9, 9);

	}

	float WhereToGo(Vector2 ballPosition, Vector2 rocketPosition)
	{
		return (ballPosition.x - rocketPosition.x);
	}
	void Update()
	{
		lives = lifeParent.transform.childCount;
	}
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == MyTags.Rocket_Tag||target.gameObject.tag==MyTags.ExtendedRocket_Tag)
		{
			SoundManager.instance.RocketSoundFX();
			float x = WhereToGo(transform.position, target.transform.position);
			Vector2 dir = new Vector2(x, 1f);
			myBody.velocity = dir * speed;
		}
		
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == MyTags.BottomBorder_Tag)
		{
			Destroy(gameObject);
		}

	}
	
}
