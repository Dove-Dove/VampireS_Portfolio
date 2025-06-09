using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    Vector2 vec = new Vector2();
    Rigidbody2D Rigidbody;
    SpriteRenderer Sprite;
    

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        vec.x = Input.GetAxis("Horizontal");
        vec.y = Input.GetAxis("Vertical");
        Sprite.flipX = true;
        vec.Normalize();

        Rigidbody.velocity = vec * speed;
    }

}
