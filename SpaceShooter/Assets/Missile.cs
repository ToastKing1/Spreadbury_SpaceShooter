using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform enemy;
    public float speed = 2f;

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

        Rotation();

        
        if (distance < 2)
        {
            
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
        else
        {
            transform.position += (enemy.position - transform.position) * 0.05f * speed * Time.deltaTime;
        }
        
        
    }

    void Rotation()
    {
        float angle = Mathf.Atan2(enemy.position.y - transform.position.y, enemy.position.x - transform.position.x) * Mathf.Rad2Deg;
        

        angle = StandardizeAngle(angle);

        if (transform.eulerAngles.z < angle)
        {
            transform.eulerAngles += new Vector3(0, 0, angle) * 5 * Time.deltaTime;
        }
        if (transform.eulerAngles.z < angle)
        {
            transform.eulerAngles += new Vector3(0, 0, -angle) * 5 * Time.deltaTime;
        }

        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle) * 10);


    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360;

        inAngle = (inAngle + 360) % 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
