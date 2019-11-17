using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonAI : MonoBehaviour
{
    public GameObject player;

    //State determines if the racoon is on patrol, chasing
    //the player, or going back to patrol
    //0 = on patrol
    //1 = chasing player
    //2 = going back to patrol
    private int state;
    private float waitTime;

    //Scripts to change to
    public Patrol p;
    public FollowPlayer fp;
    public ReturnToPatrol rp;

    //Current node Racoon is on
    public MoveNode currentNode;


    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        waitTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Checking to see if player is close by
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if ( dist < 0 )
        {
            dist = dist * -1;
        }

        if ( dist <= 4 && waitTime <= 0 )
        {
            if ( dist <= 0.75 )
            {
                state = 2;
                waitTime = 3f;
            }
            state = 1;
        } else
        {
            if ( currentNode.getPosition().x == p.getCurrrentNode().getPosition().x && currentNode.getPosition().y == p.getCurrrentNode().getPosition().y )
            {
                state = 0;
            } else
            {
                state = 2;
            }
        }

        if (state == 1)
        {
            //Chasing player
            p.SetActive(0);
            fp.SetActive(1, currentNode);
            rp.SetActive(0, null);
        }
        else if (state == 2) {
            //Go back to the patrol route
            p.SetActive(0);
            fp.SetActive(0, null);
            rp.SetActive(1, currentNode);
        }
        else if (state == 0)
        {
            //Go on patrol
            p.SetActive(1);
            fp.SetActive(0, null);
            rp.SetActive(0, null);
        }

        if (waitTime <= 0)
        {
            waitTime = 0;
        }
        else {
            waitTime -= Time.deltaTime;
        }

    }

    public void setCurrentNode( MoveNode m )
    {
        currentNode = m;
    }
}
