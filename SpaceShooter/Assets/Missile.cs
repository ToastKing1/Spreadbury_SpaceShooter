using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform enemy;
    public float speed = 1f;

    void Start()
    {
        enemy = GameObject.Find("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) return;

        float distance = Mathf.Sqrt((enemy.position.x - transform.position.x) * (enemy.position.x - transform.position.x) +

            (enemy.position.y - transform.position.y) * (enemy.position.y - transform.position.y));

        if (distance < 2)
        {
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
        else
        {
            transform.position += (enemy.position - transform.position) * speed * Time.deltaTime;
        }
    }
}
