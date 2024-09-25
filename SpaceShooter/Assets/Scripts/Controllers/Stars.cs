using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    public int star = 0;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    void DrawConstellation()
    {

        drawingTime += 1 * Time.deltaTime;

        Vector3 endPoint = Vector3.Lerp(starTransforms[star].position, starTransforms[(star + 1) % starTransforms.Count].position, drawingTime);

                Debug.DrawLine(starTransforms[star].position, endPoint, Color.white);

        if (drawingTime > 1)
        {
            drawingTime = 0;
            star = (star + 1) % starTransforms.Count;
        }
            
            

        



    }
}
