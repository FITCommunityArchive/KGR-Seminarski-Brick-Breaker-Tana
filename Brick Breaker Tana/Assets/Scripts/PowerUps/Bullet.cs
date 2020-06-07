using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public static int count = 0;
    private Rigidbody2D myBody;
    // Start is called before the first frame update

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        myBody.velocity = Vector2.up * speed;
        Physics2D.IgnoreLayerCollision(9, 14);
        Physics2D.IgnoreLayerCollision(10, 14);
        Physics2D.IgnoreLayerCollision(11, 14);
        Physics2D.IgnoreLayerCollision(12, 14);
        Physics2D.IgnoreLayerCollision(13, 14);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag==MyTags.Brick_Tag||target.gameObject.tag==MyTags.TopBorder_Tag||target.gameObject.tag==MyTags.SpecialBrick_Tag)
        {
            SoundManager.instance.HitSoundFX();
            Destroy(gameObject);
        }
    }
}
