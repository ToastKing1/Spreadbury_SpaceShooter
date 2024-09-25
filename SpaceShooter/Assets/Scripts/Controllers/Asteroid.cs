using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
       target = new Vector3(Random.Range(transform.position.x+0, transform.position.x + maxFloatDistance), 
           
           Random.Range(transform.position.y + 0, transform.position.y + maxFloatDistance), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target - transform.position).normalized * moveSpeed * Time.deltaTime;


        if (arrivalDistance > (target - transform.position).magnitude)
        {
            target = new Vector3(Random.Range(0, maxFloatDistance), Random.Range(0, maxFloatDistance), 0);
        }
    }
}
