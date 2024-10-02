using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{


    public float AngularSpeed = 3f;
    public int TargetAngle;
    // Start is called before the first frame update
    void Start()
    {
        TargetAngle = Random.Range(0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y) + (transform.up * 3), Color.cyan);

        Rotate();
    }

    void Rotate()
    {
        if (transform.eulerAngles.z >= TargetAngle)
        {
            AngularSpeed = 0;

            transform.eulerAngles = new Vector3(0, 0, TargetAngle);
        }
        else
        {
            transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }
    }
}
