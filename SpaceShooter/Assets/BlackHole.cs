using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    public Transform player;

    public float speed = 3.0f;

    void Update()
    {
        float distance = Mathf.Sqrt((player.position.x - transform.position.x) * (player.position.x - transform.position.x) +

            (player.position.y - transform.position.y) * (player.position.y - transform.position.y));

        if (distance < 5f)
        {
            speed = 2.5f - (distance * 0.5f);
            player.position += (transform.position - player.position) * speed * Time.deltaTime;

            
        }
    }
}
