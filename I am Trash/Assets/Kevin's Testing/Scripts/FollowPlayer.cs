using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private int active;
    public MoveNode currentNode;

    // Start is called before the first frame update
    void Start()
    {
        active = 0;
        currentNode = null;
    }

    // Update is called once per frame
    void Update()
    {
        if ( active == 1 )
        {
            
        }
    }
}
