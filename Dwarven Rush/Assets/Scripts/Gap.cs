using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gap : MonoBehaviour
{
    private GameObject floor;
    private GameObject dwarf;

    private BoxCollider2D floor_collider;
    private BoxCollider2D gap_collider;
    private BoxCollider2D dwarf_collider;

    private void OnTriggerStay2D(Collider2D other)
    {
        float left_bound, right_bound;

        left_bound = gameObject.transform.position.x - gap_collider.bounds.extents.x;
        right_bound = gameObject.transform.position.x + gap_collider.bounds.extents.x;

        float dwarf_left, dwarf_right;

        dwarf_left = dwarf.transform.position.x - dwarf_collider.bounds.extents.x;
        dwarf_right = dwarf.transform.position.x + dwarf_collider.bounds.extents.x;

        if (left_bound < dwarf_left && right_bound > dwarf_right)
        {
            floor_collider.enabled = false;
        }
        else
        {
            floor_collider.enabled = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        floor_collider.enabled = true;
    }

    void Start()
    {
        dwarf = GameObject.FindGameObjectWithTag("Dwarf");
        floor = GameObject.FindGameObjectWithTag("Main Floor");

        gap_collider = GetComponent<BoxCollider2D>();
        dwarf_collider = dwarf.GetComponent<BoxCollider2D>();
        floor_collider = floor.GetComponent<BoxCollider2D>();
    }
}
