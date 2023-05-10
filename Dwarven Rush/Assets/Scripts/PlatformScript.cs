using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private BoxCollider2D platform_collider;
    private GameObject dwarf;
    private BoxCollider2D dwarf_collider;

    void Start()
    {
        platform_collider = GetComponent<BoxCollider2D>();
        dwarf = GameObject.FindGameObjectWithTag("Dwarf");
        dwarf_collider = dwarf.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {

        }
    }
}
