using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RacoonRoam : MonoBehaviour
{
    public Tilemap groundMap;
    public Tilemap wallsMap;

    public GameObject player;
    public PlayerControler pc;
    
    public int delayTime = 3;
    private int delay = 0;

    private Vector3 target;
    private int dir;

    public int vision = 6;
    public int speed = 3;
    private int trash = 0;

    public Animator animator;
    private int animDelay = 20;
    private int scale = 1;
    private int vert = 0;
    private int horz = 0;

    // Start is called before the first frame update
    void Start()
    {
        delay = 0;
        target = new Vector3(transform.position.x, transform.position.y, 0);
        dir = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {

        if (delay <= 0 && transform.position == target && trash == 0)
        {
            //-----------------------------------------------------------------------------------------------------------------------------------------
            //Checking to see if player is close by
            float dist = Vector2.Distance(player.transform.position, transform.position);
            if (dist < 0)
            {
                dist = dist * -1;
            }

            if (dist <= vision)
            {
                //Find player's coordinates
                float pX = player.transform.position.x;
                float pY = player.transform.position.y;

                //Get our coordinates
                float eX = transform.position.x;
                float eY = transform.position.y;

                float distX = eX - pX;
                float distY = eY - pY;

                if (Mathf.Abs(distX) > Mathf.Abs(distY))
                {
                    //The player is to the left/right
                    if (distX < 0)
                    {
                        //The player is to the right, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y - 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go right
                            target = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                        }
                        else
                        {
                            if (distY < 0)
                            {
                                //The player is above, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y + 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go up
                                    target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                                }
                            }
                            else
                            {
                                //The player is below
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 1.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go down
                                    target = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        //The player is to the left, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 1.5f), (int)(transform.position.y - 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go right
                            target = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                        }
                        else
                        {
                            if (distY < 0)
                            {
                                //The player is above, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y + 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go up
                                    target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                                }
                            }
                            else
                            {
                                //The player is below
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 1.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go down
                                    target = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (distY < 0)
                    {
                        //The player is above, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y + 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go up
                            target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                        } else
                        {
                            //The player is to the left/right
                            if (distX < 0)
                            {
                                //The player is to the right, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                                }
                            }
                            else
                            {
                                //The player is to the left, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 1.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        //The player is below
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 1.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go down
                            target = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                        } else
                        {
                            //The player is to the left/right
                            if (distX < 0)
                            {
                                //The player is to the right, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                                }
                            }
                            else
                            {
                                //The player is to the left, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 1.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                int changeDir = Random.Range(0, 5);

                if (changeDir == 0)
                {
                    dir = Random.Range(0, 5);
                }

                if (dir%4 == 0)
                {
                    //Go Right
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y - 0.5f), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        target = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                    }
                } else if (dir%4 == 1)
                {
                    //Go Left
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 1.5f), (int)(transform.position.y - 0.5f), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        target = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                    }
                } else if (dir%4 == 2 )
                {
                    //Go Up
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y + 0.5f), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                    }
                } else if ( dir%4 == 3 )
                {
                    //Go Down
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 1.5f), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        target = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                    }
                }
            }
            //-----------------------------------------------------------------------------------------------------------------------------------------
        }
        else if ( delay <= 0 && transform.position == target && trash == 1 )
        {
            //Checking to see if player is close by
            float dist = Vector2.Distance(player.transform.position, transform.position);
            if (dist < 0)
            {
                dist = dist * -1;
            }

            if (dist <= vision*1.5)
            {
                //The player is too close
                //Find player's coordinates
                float pX = player.transform.position.x;
                float pY = player.transform.position.y;

                //Get our coordinates
                float eX = transform.position.x;
                float eY = transform.position.y;

                float distX = eX - pX;
                float distY = eY - pY;

                if (Mathf.Abs(distX) > Mathf.Abs(distY))
                {
                    //The player is to the left/right
                    if (distX < 0)
                    {
                        //The player is to the right, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 1.5f), (int)(transform.position.y - 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go right
                            target = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                        }
                        else
                        {
                            if (distY < 0)
                            {
                                //The player is above, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 1.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go up
                                    target = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                                }
                            }
                            else
                            {
                                //The player is below
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y + 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go down
                                    target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        //The player is to the left, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y - 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go right
                            target = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                        }
                        else
                        {
                            if (distY < 0)
                            {
                                //The player is above, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 1.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go up
                                    target = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                                }
                            }
                            else
                            {
                                //The player is below
                                targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y + 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go down
                                    target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (distY < 0)
                    {
                        //The player is above, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 1.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go up
                            target = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                        }
                        else
                        {
                            //The player is to the left/right
                            if (distX < 0)
                            {
                                //The player is to the right, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 1.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                                }
                            }
                            else
                            {
                                //The player is to the left, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        //The player is below
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y + 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go down
                            target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                        }
                        else
                        {
                            //The player is to the left/right
                            if (distX < 0)
                            {
                                //The player is to the right, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x - 1.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                                }
                            }
                            else
                            {
                                //The player is to the left, check for a wall
                                targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y - 0.5f), 0);
                                hasWall = wallsMap.GetTile(targetCell) != null;

                                if (!hasWall)
                                {
                                    //Ther is no wall, go right
                                    target = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //Drop the trash
                GameManager.gm.DropTrash(trash, transform.position);
                trash = 0;
            }
        }
        else
        {
            //animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            delay--;

            //Figure out animation
            //Find target coordinates
            float pX = target.x;
            float pY = target.y;

            //Get our coordinates
            float eX = transform.position.x;
            float eY = transform.position.y;

            float distX = eX - pX;
            float distY = eY - pY;

            if (Mathf.Abs(distX) > Mathf.Abs(distY))
            {
                //Going horizontal
                if ( distX < 0 && horz != 1)
                {
                    //going right
                    vert = 0;
                    horz = 1;
                } else if (horz != -1)
                {
                    vert = 0;
                    horz = -1;
                }
            } else
            {
                //Going vertical
                if ( distY < 0 && vert != 1)
                {
                    //go up
                    vert = 1;
                    horz = 0;
                } else if (vert != -1)
                {
                    vert = -1;
                    horz = 0;
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player" && pc.getImmunity() == 0 && trash == 0 && pc.GetTrashBag() > 0)
        if ( collision.gameObject.tag == "Player")
        {
            if ( pc.getImmunity() == 0 )
            {
                if (trash == 0)
                {
                    if (pc.GetTrashBag() > 0)
                    {
                        pc.decreaseTrashBag(1);
                        pc.setImmunity(20);
                        trash += 1;
                    }
                }
            }
        }
    }
}
