using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPatrol : MonoBehaviour
{
    private int active;
    private MoveNode targetNode;
    public MoveNode currentNode;
    private float speed;
    public RacoonAI ra;
    public Patrol p;

    // Start is called before the first frame update
    void Start()
    {
        active = 0;
        currentNode = null;
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == 1)
        {
            //if (transform.position.x == currentNode.getPosition().x && transform.position.y == currentNode.getPosition().y)
            if (Vector2.Distance(transform.position, currentNode.getPosition()) < 0.2f)
            {
                //Find Target's coordinates
                float pX = targetNode.getPosition().x;
                float pY = targetNode.getPosition().y;

                //Get our coordinates
                float eX = transform.position.x;
                float eY = transform.position.y;

                float distX = eX - pX;
                float distY = eY - pY;

                MoveNode up = currentNode.getUpNode();
                MoveNode down = currentNode.getDownNode();
                MoveNode right = currentNode.getRightNode();
                MoveNode left = currentNode.getLeftNode();

                int found = 0;

                if (Mathf.Abs(distX) > Mathf.Abs(distY))
                {
                    //The player is more right/left so go right/left if possible
                    if (distX < 0 && right != null)
                    {
                        //Player is to the right and you can move right
                        transform.position = Vector2.MoveTowards(transform.position, right.getPosition(), speed * Time.deltaTime);
                        currentNode = right;
                        found = 1;
                    }
                    else if (distX >= 0 && left != null)
                    {
                        //Player is to the left and you can move left
                        transform.position = Vector2.MoveTowards(transform.position, left.getPosition(), speed * Time.deltaTime);
                        currentNode = left;
                        found = 1;
                    }
                    else if (distY < 0 && up != null)
                    {
                        //We cannot go right or left so try to in another direction toward the player
                        //Go up
                        transform.position = Vector2.MoveTowards(transform.position, up.getPosition(), speed * Time.deltaTime);
                        currentNode = up;
                        found = 1;
                    }
                    else if (distY >= 0 && down != null)
                    {
                        //We cannot go right or left so try to in another direction toward the player
                        //Go down
                        transform.position = Vector2.MoveTowards(transform.position, down.getPosition(), speed * Time.deltaTime);
                        currentNode = down;
                        found = 1;
                    }

                    //We haven't found a direction to move so just find somewhere we can go
                    if (found == 0)
                    {
                        //We haven't found a direction to move so just find somewhere we can go
                        if (up != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, up.getPosition(), speed * Time.deltaTime);
                            currentNode = up;
                            found = 1;
                        }
                        else if (down != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, down.getPosition(), speed * Time.deltaTime);
                            currentNode = down;
                            found = 1;
                        }
                        else if (right != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, right.getPosition(), speed * Time.deltaTime);
                            currentNode = right;
                            found = 1;
                        }
                        else if (left != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, right.getPosition(), speed * Time.deltaTime);
                            currentNode = left;
                            found = 1;
                        }
                    }
                    ra.setCurrentNode(currentNode);
                }
                else
                {
                    //The player is more up/down so go up/down if possible
                    if (distY < 0 && up != null)
                    {
                        //We cannot go right or left so try to in another direction toward the player
                        //Go up
                        transform.position = Vector2.MoveTowards(transform.position, up.getPosition(), speed * Time.deltaTime);
                        currentNode = up;
                        found = 1;
                    }
                    else if (distY >= 0 && down != null)
                    {
                        //We cannot go right or left so try to in another direction toward the player
                        //Go down
                        transform.position = Vector2.MoveTowards(transform.position, down.getPosition(), speed * Time.deltaTime);
                        currentNode = down;
                        found = 1;
                    }
                    else if (distX < 0 && right != null)
                    {
                        //Player is to the right and you can move right
                        transform.position = Vector2.MoveTowards(transform.position, right.getPosition(), speed * Time.deltaTime);
                        currentNode = right;
                        found = 1;
                    }
                    else if (distX >= 0 && left != null)
                    {
                        //Player is to the left and you can move left
                        transform.position = Vector2.MoveTowards(transform.position, left.getPosition(), speed * Time.deltaTime);
                        currentNode = left;
                        found = 1;
                    }

                    //We haven't found a direction to move so just find somewhere we can go
                    if (found == 0)
                    {
                        //We haven't found a direction to move so just find somewhere we can go
                        if (up != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, up.getPosition(), speed * Time.deltaTime);
                            currentNode = up;
                            found = 1;
                        }
                        else if (down != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, down.getPosition(), speed * Time.deltaTime);
                            currentNode = down;
                            found = 1;
                        }
                        else if (right != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, right.getPosition(), speed * Time.deltaTime);
                            currentNode = right;
                            found = 1;
                        }
                        else if (left != null)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, right.getPosition(), speed * Time.deltaTime);
                            currentNode = left;
                            found = 1;
                        }
                    }

                    ra.setCurrentNode(currentNode);
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentNode.getPosition(), speed * Time.deltaTime);
            }

        }
    }

    //Set Active
    public void SetActive(int n, MoveNode m)
    {
        if (n != active)
        {
            active = n;
            currentNode = m;
            if (active == 1)
            {
                Debug.Log("Return Active");
                targetNode = p.getCurrrentNode();
            }
        }
    }

    //Set Current Node
    public void SetCurrentNode(MoveNode c)
    {
        currentNode = c;
    }
}
