using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfMovement : MonoBehaviour
{
    public float move_speed;
    public float max_speed;
    public float jump_strength;

    public bool air_jump;
    private bool awaiting_jump = false;

    private Rigidbody2D body;
    private BoxCollider2D box_collider;

    bool TouchingGround()
    {
        if (air_jump) { return true; }
        // can replace with other conditions to allow double or triple jump etc
        
        Vector3 collider_floor = gameObject.transform.position;
        collider_floor.y -= box_collider.bounds.extents.y + 0.1f;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)collider_floor, Vector2.down, 0.2f);
        
        return hit.collider != null;
    }

    bool Jumping()
    {
        return awaiting_jump && TouchingGround();
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        box_collider = body.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            awaiting_jump = true;
        }
        // this is a scuffed work around to make sure the jump is detected even if the
        // space key is pressed on a non FixedUpdate frame
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector2.left * move_speed, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector2.right * move_speed, ForceMode2D.Force);
        }

        Vector3 velocity = body.velocity;

        if (Jumping())
        {
            velocity.y = jump_strength;
        }
        awaiting_jump = false;

        if (Mathf.Abs(velocity.x) >= max_speed)
        {
            float direction = velocity.x == 0 ? 0 : velocity.x / Mathf.Abs(velocity.x);
            velocity.x = max_speed * direction;
        }

        body.velocity = velocity;
    }
}
