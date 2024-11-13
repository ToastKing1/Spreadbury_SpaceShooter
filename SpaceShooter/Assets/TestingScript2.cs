using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript2 : MonoBehaviour
{
    public Collider2D playerCollider;
    public Collider2D selfCollider;

    void Start()
    {
        Physics2D.GetIgnoreCollision(playerCollider, selfCollider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    
}
