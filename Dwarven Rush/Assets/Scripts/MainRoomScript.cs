using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomScript : MonoBehaviour
{
    private LogicScript logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dwarf")
        {
            logic.EndGame();
        }
    }
}
