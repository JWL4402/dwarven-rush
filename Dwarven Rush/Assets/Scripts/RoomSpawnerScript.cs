using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnerScript : MonoBehaviour
{    
    public GameObject[] rooms;

    public float min_interval;
    public float max_interval;
    public float start_interval;

    private float timer;
    private float interval;
    private GameObject next_room;
    
    void Spawn()
    {
        timer = 0f;
        interval = Random.Range(min_interval, max_interval);
        next_room = rooms[Random.Range(0, rooms.Length)];

        Instantiate(next_room, new Vector3(0, 0, -15), Quaternion.identity, gameObject.transform);
        // Spawn offscreen, room movement script will handle starting position
    }

    void Start()
    {
        interval = start_interval;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Spawn();
        }
    }
}
