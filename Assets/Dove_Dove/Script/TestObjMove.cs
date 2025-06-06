using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    Vector2 vec = new Vector2();
    Rigidbody2D Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        vec.x = Input.GetAxis("Horizontal");
        vec.y = Input.GetAxis("Vertical");
        vec.Normalize();

        Rigidbody.velocity = vec * speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
