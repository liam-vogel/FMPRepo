using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class homingWeapon : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public int speed;
    public float rotateSpeed;
    //public Vector2Int mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //mousePos.x = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - .5f);
        //mousePos.y = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - .5f);

        Vector2 direction = (Vector2)target.position - rb.position;
        //Vector2 direction = (Vector2)mousePos - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
        //rb.velocity = direction * speed;
    }
}
