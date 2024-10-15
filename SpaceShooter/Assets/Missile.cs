using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public Transform enemy;
    public float speed = 2f;
    //public float angleSpeed = 5.0f;

    void Start()
    {
        enemy = GameObject.Find("Enemy").transform;
    }

    void Update()
    {
        if (enemy == null) return;

        float distance = Mathf.Sqrt((enemy.position.x - transform.position.x) * (enemy.position.x - transform.position.x) +

            (enemy.position.y - transform.position.y) * (enemy.position.y - transform.position.y));

        Rotation();

        
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

    void Rotation()
    {
        float angle = Mathf.Atan2(enemy.position.y - transform.position.y, enemy.position.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }



    /*
    if (transform.eulerAngles.z < angle)
    {

        transform.Rotate(0, 0, angleSpeed * Time.deltaTime);
       // transform.eulerAngles = new Vector3(0, 0, angle) * Time.deltaTime;
    }
    if (transform.eulerAngles.z > angle)
    {
        transform.Rotate(0, 0, -angleSpeed * Time.deltaTime);
        //transform.eulerAngles = new Vector3(0, 0, -angle) * Time.deltaTime;
    }
    */

    //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle) * 10);

}
