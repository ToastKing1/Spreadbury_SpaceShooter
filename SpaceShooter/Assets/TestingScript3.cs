using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TestingScript3 : MonoBehaviour
{
    public GameObject player;
    public Vector2 playerVector2;
    public Transform self;
    void Update()
    {
        playerVector2 = player.transform.position;
        RaycastHit2D lineCast = Physics2D.Linecast(new Vector2(0, 0), playerVector2);
        Debug.Log(lineCast.collider);
        if (lineCast.collider.gameObject.name == "Asteroid")
        {
            Destroy(lineCast.collider.gameObject);
        }
    }
}
