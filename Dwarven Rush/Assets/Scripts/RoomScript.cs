using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public float speed;
    public int points;
    public GameObject[] platforms;

    private float floor_extents;
    private float room_extents;
    private LogicScript logic;

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
            logic.AddScore(points);
        }
    }

    void Start()
    {
        BoxCollider2D room_collider = GetComponent<BoxCollider2D>();
        room_extents = room_collider.bounds.extents.x;

        GameObject floor = GameObject.FindGameObjectWithTag("Main Floor");
        floor_extents = floor.GetComponent<BoxCollider2D>().bounds.extents.x;

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        foreach (GameObject platform in platforms)
        {
            PlatformScript script = platform.GetComponent<PlatformScript>();
            script.speed = speed;
        }

        Spawn();
    }

    void Update()
    {
        Move();
        CheckOffscreen();
    }
}
