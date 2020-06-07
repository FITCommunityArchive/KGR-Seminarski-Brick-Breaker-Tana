using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
	private Shake shake;
	[SerializeField]
	private Sprite BrickImage1;
	[SerializeField]
	private Sprite BrickImage2;
	
	[SerializeField]
	private ChangeColor changeColor;
	void Start()
	{
		shake = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<Shake>();
		//ChangeToBlue();
	}

	void Update()
	{
		if (!changeColor.change)
			ChangeToBlue();
		else
		{
			ChangeToYellow();
		}
	}
	void ChangeToBlue()
	{
		GetComponent<SpriteRenderer>().sprite = BrickImage1;
		//float number = Random.Range(0f, 0.5f);
		//Invoke("ChangeToYellow", 1f);
	}
	void ChangeToYellow()
	{
		GetComponent<SpriteRenderer>().sprite = BrickImage2;
		//float number = Random.Range(0f, 0.5f);
		//Invoke("ChangeToBlue", 1f);
	}
	
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == MyTags.Ball_Tag||target.gameObject.tag==MyTags.Bullet_Tag)
		{
			shake.CamShake();
			SoundManager.instance.HitSoundFX();
			Destroy(gameObject);	
		}
	}
	
}
