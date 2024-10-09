using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProductExercise : MonoBehaviour
{
    // Start is called before the first frame update

    public float redAngle = 15;
    public float blueAngle = 30;

    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 redVector = new Vector3(transform.position.x - Mathf.Cos((270 + redAngle) * Mathf.Deg2Rad), transform.position.y - Mathf.Sin((270 + redAngle) * Mathf.Deg2Rad));

        Vector3 redVector = new Vector3(Mathf.Cos(redAngle * Mathf.Deg2Rad), Mathf.Sin(redAngle * Mathf.Deg2Rad));

        Vector3 blueVector = new Vector3(Mathf.Cos(blueAngle * Mathf.Deg2Rad), Mathf.Sin(blueAngle * Mathf.Deg2Rad));

        //Vector3 blueVector = new Vector3(transform.position.x - Mathf.Cos((270 + blueAngle) * Mathf.Deg2Rad), transform.position.y - Mathf.Sin((270 + blueAngle) * Mathf.Deg2Rad));

        float dotRB = redVector.x * blueVector.x + redVector.x * blueVector.y;

        Debug.DrawLine(transform.position, redVector, Color.red);

        Debug.DrawLine(transform.position, blueVector, Color.blue);

        if (Input.GetKey(KeyCode.Space))
        {
            
            Debug.Log(redVector.x * blueVector.x + redVector.x * blueVector.y);
        }

    }
}
