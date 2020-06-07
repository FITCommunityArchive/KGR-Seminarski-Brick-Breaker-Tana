using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBrick : MonoBehaviour
{
    [SerializeField]
    private GameObject heart;
    [SerializeField]
    private GameObject ballSpawner;
	[SerializeField]
	private GameObject extended;
	[SerializeField]
	private GameObject bulletSpawner;
	[SerializeField]
	private Sprite brokenBrickImage1;
	[SerializeField]
	private Sprite brokenBrickImage2;
	[SerializeField]
	private Sprite brickImage1;
	[SerializeField]
	private Sprite brickImage2;
	private int count = 0;
	private bool change = false;
	private Shake shake;
	[SerializeField]
	private ChangeColor changeColor;

	private void Start()
	{
		shake = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<Shake>();
		ChangeToRed();
	}

	void ChangeToRed()
	{
		if(count==0)
		{
			GetComponent<SpriteRenderer>().sprite = brickImage1;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = brokenBrickImage1;
		}
		change = false;
		
	}
	void ChangeToGreen()
	{
		if (count == 0)
		{
			GetComponent<SpriteRenderer>().sprite = brickImage2;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = brokenBrickImage2;
		}
		change = true;
		
	}
	void Update()
	{
		if (!changeColor.change)
			ChangeToRed();
		else
		{
			ChangeToGreen();
		}
	}
	void OnCollisionEnter2D(Collision2D target)
	{

		if (target.gameObject.tag == MyTags.Ball_Tag||target.gameObject.tag==MyTags.Bullet_Tag)
		{
			if(count==0)
			{
				shake.CamShake();
				SoundManager.instance.HitSoundFX();
				if(change)
					GetComponent<SpriteRenderer>().sprite = brokenBrickImage2;
				else
					GetComponent<SpriteRenderer>().sprite = brokenBrickImage1;
				count++;
			}
			else
			{
				shake.CamShake();
				Destroy(gameObject);
				SoundManager.instance.HitSoundFX();

				int number = Random.Range(1, 5);
				if (number == 1)
				{
					Vector2 temp = transform.position;
					GameObject newHeart = Instantiate(heart, temp, Quaternion.identity);
				}
				else if (number == 2)
				{
					Vector2 temp = transform.position;
					GameObject newBallSpawner = Instantiate(ballSpawner, temp, Quaternion.identity);
				}
				else if (number == 3)
				{
					Vector2 temp = transform.position;
					GameObject newExtended = Instantiate(extended, temp, Quaternion.identity);
				}
				else if (number == 4)
				{
					Vector2 temp = transform.position;
					GameObject newBulletSpawner = Instantiate(bulletSpawner, temp, Quaternion.identity);
				}
				
			}
			
			
		}

	}
	
}
