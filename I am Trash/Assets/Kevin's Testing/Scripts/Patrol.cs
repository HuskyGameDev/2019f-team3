using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int nextSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        nextSpot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                nextSpot++;
                if ( nextSpot >= moveSpots.Length )
                {
                    nextSpot = 0;
                }
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
