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

    //Scripts to change to
    public Patrol p;
    public FollowPlayer fp;

    //Current node Racoon is on
    public MoveNode currentNode;


    // Start is called before the first frame update
    void Start()
    {
        state = 0;
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

        if ( dist <= 3 )
        {
            state = 1;
        } else
        {
            state = 0;
        }

        if ( state == 1 )
        {
            p.setActive(0);
        } else if ( state == 0 )
        {
            p.setActive(1);
        }

    }

    public void setCurrentNode( MoveNode m )
    {
        currentNode = m;
    }
}
