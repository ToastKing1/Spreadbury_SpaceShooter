using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 velocity = new Vector3(0.001f, 0f);

    private float timeToReachSpeed = 3f;
    private float targetSpeed = 4f;
    private float acceleration;
    private float decelerationTime;

    public int circlePoints = 5;
    public float circleRadius = 5;


    public GameObject powerUpPrefab;
    public int powerUpAmount = 3;
    public float powerUpRadius = 3;



    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
        decelerationTime = targetSpeed / timeToReachSpeed;
    }

    void Update()
    {
        Debug.DrawLine(Vector3.zero, transform.position, Color.blue);


        transform.position += velocity * Time.deltaTime;

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                PlayerMovement(Vector3.up);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                PlayerMovement(Vector3.down);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                PlayerMovement(Vector3.left);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                PlayerMovement(Vector3.right);
            }
        }
        else
        {
            velocity -= velocity.normalized * (decelerationTime * Time.deltaTime);
        }

            if (Input.GetKey(KeyCode.T))
            {
                DetectAsteroids(2.5f, asteroidTransforms);
            }

        EnemyRadar(circleRadius, circlePoints);

        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnPowerUps(powerUpRadius, powerUpAmount);
        }
    }


    void PlayerMovement(Vector3 movement)
    {
        velocity += acceleration * movement * Time.deltaTime;
        if (velocity.magnitude > targetSpeed)
        {
            velocity = velocity.normalized * targetSpeed;
        }
    }

    void DetectAsteroids(float maxRange, List<Transform> asteroidsList)
    {
        for (int eA = 0; eA < asteroidsList.Count; eA++)
        {
            Vector3 direction = asteroidsList[eA].position - transform.position;

            if (direction.magnitude <= maxRange)
            {
                Debug.DrawLine(transform.position, asteroidsList[eA].position, Color.green);
            }
        }
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        float angleAmount = 360 / circlePoints;

        angleAmount *= Mathf.Deg2Rad;

        float distance = Mathf.Sqrt((enemyTransform.position.x - transform.position.x) * (enemyTransform.position.x - transform.position.x) +
            (enemyTransform.position.y - transform.position.y) * (enemyTransform.position.y - transform.position.y)
            );


        if (distance <= radius)
        {
            for (int i = 0; i < circlePoints; i++)
            {

                Debug.DrawLine(transform.position + new Vector3(Mathf.Cos(angleAmount * i), Mathf.Sin(angleAmount * i), 0f) * radius,
                    transform.position + new Vector3(Mathf.Cos(angleAmount * (i + 1)), Mathf.Sin(angleAmount * (i + 1)), 0f) * radius,
                    Color.red
                    );
            }
        }
        else
        {
            for (int i = 0; i < circlePoints; i++)
            {
                /*
                Debug.DrawLine(
                    ( new Vector3(Mathf.Cos((angleAmount * i )), Mathf.Sin(angleAmount * i), 0f) * radius ), 
                    ( new Vector3(Mathf.Cos(angleAmount * (i+1)), Mathf.Sin(angleAmount * (i + 1)), 0f) * radius), Color.green);
                */

                Debug.DrawLine(transform.position + new Vector3(Mathf.Cos(angleAmount*i),  Mathf.Sin(angleAmount * i), 0f) * radius,
                    transform.position + new Vector3(Mathf.Cos(angleAmount * (i+1)), Mathf.Sin(angleAmount * (i+1)), 0f) * radius,
                    Color.green
                    );
            }
        }

    }

    public void SpawnPowerUps(float radius, int numberOfPowerups)
    {
        float angleAmount = 360 / numberOfPowerups;

        angleAmount *= Mathf.Deg2Rad;

        for (int i = 0; i < numberOfPowerups; i++)
        {
            Instantiate(powerUpPrefab, transform.position + new Vector3(Mathf.Cos(angleAmount * i), Mathf.Sin(angleAmount * i), 0f) * radius, Quaternion.identity);
        }
    }

}
