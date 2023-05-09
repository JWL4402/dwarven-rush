using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnerScript : MonoBehaviour
{    
    public GameObject[] rooms;
    public GameObject basic_room;
    public float min_interval;
    public float max_interval;

    private float timer;
    private float interval;
    private GameObject next_room;
    
    void Spawn()
    {
        //timer = 0f;
        //interval = Random.Range(min_interval, max_interval);
        //next_room = rooms[Random.Range(0, rooms.Length)];

        //Instantiate(next_room, new Vector3(25, 0, 0), Quaternion.identity, gameObject.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject starter_room = Instantiate(basic_room, Vector3.zero, Quaternion.identity, gameObject.transform);
        //RoomMovement script = starter_room.GetComponent<RoomMovement>();
        //script.time = max_interval;

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Spawn();
        }
    }
}
