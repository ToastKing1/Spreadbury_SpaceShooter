using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingScript : MonoBehaviour
{
    public Rigidbody2D centerTest; 
    void Start()
    {
        print(centerTest.centerOfMass);

        centerTest.centerOfMass = new Vector2(1, 0);

        print(centerTest.centerOfMass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
