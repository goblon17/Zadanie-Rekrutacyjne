using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private new Rigidbody2D rigidbody;
    private Vector2 direction = new Vector2(0, 0);

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
