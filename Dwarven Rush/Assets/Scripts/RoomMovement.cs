using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    //public float speed;
    public float time;
    public BoxCollider2D floor_collider;

    void Move()
    {
        float speed = floor_collider.bounds.size.x / time;
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }

    void CheckOffscreen()
    {
        //float rightmost_pos_x = floor_collider.bounds.extents.x + transform.position.x;
        Debug.Log(floor_collider.bounds.extents.x);
        if (floor_collider.bounds.extents.x * -2 > transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        floor_collider = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckOffscreen();
    }
}
