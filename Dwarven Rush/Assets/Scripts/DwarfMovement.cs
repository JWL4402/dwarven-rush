using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfMovement : MonoBehaviour
{
    public float move_speed;
    public float max_speed;
    public float jump_strength;
    private bool jumping = false;

    private Rigidbody2D body;

    bool TouchingGround()
    {
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
        // this is a scuffed work around to make sure the jump is detected even if the
        // space key is pressed on a non FixedUpdate frame
    }

    void FixedUpdate()
    {
        Debug.Log(jumping);
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector2.left * move_speed, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector2.right * move_speed, ForceMode2D.Force);
        }

        Vector3 velocity = body.velocity;

        if (jumping && TouchingGround())
        {
            velocity.y = jump_strength;
            jumping = false;
        }

        if (Mathf.Abs(velocity.x) >= max_speed)
        {
            float direction = velocity.x == 0 ? 0 : velocity.x / Mathf.Abs(velocity.x);
            Debug.Log(direction);
            velocity.x = max_speed * direction;
        }

        body.velocity = velocity;
    }
}
