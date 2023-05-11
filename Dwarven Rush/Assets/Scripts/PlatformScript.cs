using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float speed;

    private GameObject dwarf;
    private DwarfMovement dwarf_movement;
    private BoxCollider2D dwarf_collider;
    //private BoxCollider2D platform_collider;

    private void Start()
    {
        dwarf = GameObject.FindGameObjectWithTag("Dwarf");
        dwarf_movement = dwarf.GetComponent<DwarfMovement>();
        dwarf_collider = dwarf.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider != dwarf_collider) { return; }
        dwarf_movement.SuggestMovement(Vector3.left * speed * Time.deltaTime);
    }
}
