using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    public float thrustForce = 1f;
    Rigidbody2D rb;
    private static object GetDebuggerDisplay()
    {
        throw new NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            //Calculate Mouse Direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction =(mousePos - transform.position).normalized;
          
            // Move player in direction of mouse
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    Destroy(gameObject);
    }


}