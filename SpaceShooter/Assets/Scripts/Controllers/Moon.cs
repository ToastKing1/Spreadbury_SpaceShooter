using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    public float radius = 2f;
    public float speed = 1f;
    float angleAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, speed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        angleAmount += speed*Time.deltaTime;

        transform.position = planetTransform.position + new Vector3(Mathf.Cos(angleAmount), Mathf.Sin(angleAmount), 0f) * radius;
    }
}
