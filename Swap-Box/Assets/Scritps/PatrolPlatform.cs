using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPlatform : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float patrolDistance = 5f; // Adjust the distance the platform will patrol

    private bool movingRight = true;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= originalPosition.x + patrolDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= originalPosition.x - patrolDistance)
            {
                movingRight = true;
            }
        }
    }
}
