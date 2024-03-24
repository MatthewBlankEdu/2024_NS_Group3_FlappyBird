using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdController : MonoBehaviour
{
    public Vector2 jumpForce;
    public float maxVerticalVelocity = 5;
    public Rigidbody2D rigidbody2D;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
        }

        if (rigidbody2D.velocity.y > maxVerticalVelocity)
        {
            rigidbody2D.velocity = new Vector2(0, maxVerticalVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Application.LoadLevel("FlappyBird");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pipes"))
        {
            points++;
        }
    }
}