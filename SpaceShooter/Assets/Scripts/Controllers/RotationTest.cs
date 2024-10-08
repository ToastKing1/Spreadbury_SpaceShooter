using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

        if (transform.eulerAngles.z != TargetAngle)
        {
            transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }
        if (transform.eulerAngles.z >= TargetAngle)
        {
            transform.eulerAngles = new Vector3(0, 0, TargetAngle);
        }
    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360;

        inAngle = (inAngle + 360) % 360;

        if(inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
