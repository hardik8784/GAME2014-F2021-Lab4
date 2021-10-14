using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]

    [Range(0.0f,200.0f)]
    public float HorizontalForce;

    [Range(0.0f,1.0f)]
    public float Decay;

    public Bounds bounds;

    private Rigidbody2D RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        RigidBody.AddForce(new Vector2(x * HorizontalForce, 0.0f));

        RigidBody.velocity *= (1.0f - Decay);
    }

    private void CheckBounds()
    {
        //Left Side
        if(transform.position.x < bounds.Min)
        {
            transform.position = new Vector2( bounds.Min, transform.position.y);
        }

        //Right Side
        if(transform.position.x > bounds.Max)
        {
            transform.position = new Vector2(bounds.Max, transform.position.y);
        }
    }
}
