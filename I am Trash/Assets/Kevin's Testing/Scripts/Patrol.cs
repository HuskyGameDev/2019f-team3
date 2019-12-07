using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public int active;

    public MoveNode[] moveSpots;
    private int nextSpot;

    public RacoonAI ra;

    // Start is called before the first frame update
    void Start()
    {
        //active = 1;
        waitTime = startWaitTime;
        nextSpot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ( active == 1 )
        {
            ra.setCurrentNode(moveSpots[nextSpot]);
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].getPosition(), speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[nextSpot].getPosition()) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    nextSpot++;
                    if (nextSpot >= moveSpots.Length)
                    {
                        nextSpot = 0;
                    }
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    //Set Active
    public void SetActive(int n)
    {
        if (n != active)
        {
            active = n;
            if ( active == 1 )
            {
                Debug.Log("Patrol Active");
            }
        }
    }

    //Get the current Node
    public MoveNode getCurrrentNode()
    {
        return moveSpots[nextSpot];
    }
}
