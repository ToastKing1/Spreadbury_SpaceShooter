using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Energy_Shield : MonoBehaviour
{

    public float radius = 2;
    public float speed = 2;
    public float time = 0;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Motion();

        Rotation();
    }

    public void Motion()
    {
        if (time > 14.15)
        {
            GameObject.Find("Player").gameObject.GetComponent<Player>().shieldOn = false;
            Destroy(gameObject);
        }
        else
        {
            time += speed * Time.deltaTime;

            transform.position = player.position + new Vector3(Mathf.Cos(time), Mathf.Sin(time), 0f) * radius;
        }
    }

    public void Rotation()
    {

        transform.RotateAround(player.position, transform.position, 100*Time.deltaTime);
    }


}
