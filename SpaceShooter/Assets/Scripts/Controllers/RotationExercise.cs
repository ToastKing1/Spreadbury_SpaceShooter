using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExercise : MonoBehaviour
{

    public Transform target;

    public float AngularSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, target.position, Color.blue);

        Vector3 newAngle = transform.position - target.position;

        float TargetAngle = Mathf.Atan2(newAngle.y, newAngle.x) * Mathf.Rad2Deg;

        TargetAngle = StandardizeAngle(TargetAngle);


        if (transform.eulerAngles.z < TargetAngle)
        {
            transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }
        if (transform.eulerAngles.z > TargetAngle)
        {
            //transform.eulerAngles = new Vector3(0, 0, TargetAngle) * Time.deltaTime;
            transform.Rotate(0, 0, -AngularSpeed * Time.deltaTime);
        }
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
