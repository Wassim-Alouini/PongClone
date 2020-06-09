using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRackets : MonoBehaviour
{
    public string axis;
    private Rigidbody2D rb;
    public float speed = 3.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        float v = Input.GetAxisRaw(axis) * speed;
        rb.velocity = new Vector2(0, v);
    }
}
