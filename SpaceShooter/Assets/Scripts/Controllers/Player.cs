﻿using System.Collections;
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

}