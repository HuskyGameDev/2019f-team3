using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNode : MonoBehaviour
{
    public MoveNode up = null;
    public MoveNode down = null;
    public MoveNode left = null;
    public MoveNode right = null;

    public MoveNode getUpNode()
    {
        return up;
    }

    public MoveNode getDownNode()
    {
        return down;
    }

    public MoveNode getLeftNode()
    {
        return left;
    }

    public MoveNode getRightNode()
    {
        return right;
    }

    public Vector2 getPosition()
    {
        return transform.position;
    }
}
