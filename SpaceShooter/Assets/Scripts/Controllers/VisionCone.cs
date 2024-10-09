using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    // Start is called before the first frame update

    public float sight = 1f;
    public float visionAngle = 45f;

    public Transform targetTransform;
    public float angularSpeed;

    public float detectionAngle;
    public float detectionRadius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        visionCone();

        /*
        //convert this into an angle
        Vector3 currentFacingDireciton = transform.up;
        float facingAngle = Mathf.Atan2(currentFacingDireciton.y, currentFacingDireciton.x) * Mathf.Rad2Deg;
        
        //convert this into an angle
        Vector3 targetDirection = targetTransform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(facingAngle, targetAngle);
        Debug.DrawLine(transform.position, transform.position + transform.up);
        Debug.DrawLine(transform.position, targetDirection + transform.position);

        if (deltaAngle > 0)
        {
            transform.Rotate(0f, 0f, angularSpeed * Time.deltaTime);
        }
        else if (deltaAngle < 0)
        {
            transform.Rotate(0f, 0f, -angularSpeed * Time.deltaTime);
        }
        */

    }

    public void visionCone()
    {

        Vector3 lookingDirection = transform.up;

        // Swithcing from vector to angle in terms of the looking direction
        float lookingAngle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;

        // TIlting the angle to the lft and right to get the limits of the field of ivew for the vision cone
        float leftAngle = lookingAngle + detectionAngle / 2;
        float rightAngle = lookingAngle - detectionAngle / 2;

        // switching from angle to vector in terms of the limits of the field of view for the vision cone
        Vector3 leftVector = new Vector3(Mathf.Cos(leftAngle * Mathf.Deg2Rad), Mathf.Sin(leftAngle * Mathf.Deg2Rad));
        Vector3 rightVector = new Vector3(Mathf.Cos(rightAngle * Mathf.Deg2Rad), Mathf.Sin(rightAngle * Mathf.Deg2Rad));

        Debug.DrawLine(transform.position, leftVector * detectionRadius + transform.position);
        Debug.DrawLine(transform.position, rightVector * detectionRadius + transform.position);

        // is the object too far to be visible
        bool inView = Vector3.Distance(transform.position, targetTransform.position) < detectionRadius;
        // is the object in the field of view

        bool targetIsInFOV = lookingAngle < leftAngle && lookingAngle > rightAngle;


        /*
        Color lineColour;
        if (inView && targetIsInFOV)
        {
            lineColour = Color.green;
        }
        else
        {
            lineColour = Color.red;
        }
        */




        /*
        Vector3 positiveVector = new Vector3(transform.position.x - Mathf.Cos(visionAngle * Mathf.Deg2Rad), transform.position.y - Mathf.Sin(visionAngle * Mathf.Deg2Rad));

        Vector3 negativeVector = new Vector3(transform.position.x - Mathf.Cos(-visionAngle * Mathf.Deg2Rad), transform.position.y - Mathf.Sin(-visionAngle * Mathf.Deg2Rad));

        float positiveAngle = Mathf.Atan2(positiveVector.y, positiveVector.x) * sight * Mathf.Rad2Deg;

        float negativeAngle = Mathf.Atan2(negativeVector.y, negativeVector.x) * sight * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(positiveAngle, negativeAngle);

        Debug.DrawLine(transform.position, positiveVector.normalized * sight);

        Debug.DrawLine(transform.position, negativeVector.normalized * sight);
        */


    }
}
