using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 1;

    private bool stopped = false;
    private Transform playerTransform;
    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (stopped)
        {
            return;
        }

        Vector2 direction = (transform.position - playerTransform.position).normalized;
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        float distanceMultiplier = Mathf.Clamp(1 / (distance * distance), 0, 1);
        rigidbody.velocity = distanceMultiplier * maxSpeed * direction;
    }

    public void StopMovement()
    {
        stopped = true;
        rigidbody.velocity = new Vector2(0, 0);
        rigidbody.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopMovement();
        }
    }
}
