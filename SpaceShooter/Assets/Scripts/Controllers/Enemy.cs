using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private float timeToReachSpeed = 5f;
    private float targetSpeed = 4f;
    private float acceleration;
    Vector3 velocity;

    public Transform playerTransform;

    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
    }
    private void Update()
    {
        float distance = Mathf.Sqrt((playerTransform.position.x - transform.position.x) + (playerTransform.position.y - transform.position.y));

        Debug.Log(distance);

        if (distance < 2f)
        {
            velocity = Vector3.zero;
            Debug.DrawLine(transform.position, playerTransform.position, Color.red);
        }
        else
        {

            velocity += (playerTransform.position - transform.position) * acceleration * Time.deltaTime;


            transform.position += velocity * Time.deltaTime;
        }
    }

}
