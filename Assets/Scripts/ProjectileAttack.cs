using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform attackPoint;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent < Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
