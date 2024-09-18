using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    void DrawConstellation()
    {

        for (int i = 0; i < starTransforms.Count - 1; i++)
        {
            float ratio = 0.0f;
            while (ratio < 1.0f)
            {
                Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position * ratio, Color.white);
            }
        
        }

    }
}
