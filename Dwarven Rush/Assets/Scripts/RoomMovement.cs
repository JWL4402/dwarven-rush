using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    public float speed;

    private float floor_extents;
    private float room_extents;

    void Spawn()
    {
        Vector3 spawn_pos = Vector3.right * (room_extents + floor_extents);
        transform.position = spawn_pos;
    }
    void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }

    void CheckOffscreen()
    {
        if ((room_extents + floor_extents) * -1 > transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        BoxCollider2D room_collider = GetComponent<BoxCollider2D>();
        room_extents = room_collider.bounds.extents.x;

        GameObject floor = GameObject.FindGameObjectWithTag("Main Floor");
        floor_extents = floor.GetComponent<BoxCollider2D>().bounds.extents.x;

        Spawn();
    }

    void Update()
    {
        Move();
        CheckOffscreen();
    }
}
