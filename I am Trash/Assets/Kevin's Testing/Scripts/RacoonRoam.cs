using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RacoonRoam : MonoBehaviour
{
    public GameObject player;

    public Tilemap groundMap;
    public Tilemap wallsMap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Checking to see if player is close by
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist < 0)
        {
            dist = dist * -1;
        }

        if (dist < 6)
        {
            //Code for finding walls:
            //Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y - 0.5f), 0);

            //Find player's coordinates
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            //Get our coordinates
            float eX = transform.position.x;
            float eY = transform.position.y;

            //Distances
            float distX = eX - pX;
            float distY = eY - pY;

            //See where the player is relative to the racoon
            if (Mathf.Abs(distX) > Mathf.Abs(distY))
            {
                //The player is more to the left or right of us so move that way.
                if (distX < 0)
                {
                    //Player is to the right
                    //Check to see if there is no wall in that direction
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x + 1f), (int)(transform.position.y), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        //There is no wall in that direction
                        transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                    } else
                    {
                        //There is a wall in the way so check to see if I can go up or down
                        if (distY < 0)
                        {
                            //Player is above
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x), (int)(transform.position.y + 1f), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                        else if (distY >= 0)
                        {
                            //Player is below
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x), (int)(transform.position.y - 1f), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                    }
                }
                else if (distX >= 0)
                {
                    //Player is to the left
                    //Check to see if there is no wall in that direction
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 1f), (int)(transform.position.y), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        //There is no wall in that direction
                        transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                    } else
                    {
                        //There is a wall in the way so check to see if I can go up or down
                        if (distY < 0)
                        {
                            //Player is above
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x), (int)(transform.position.y + 1f), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                        else if (distY >= 0)
                        {
                            //Player is below
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x), (int)(transform.position.y - 1f), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                    }
                }

            } else
            {
                //The player is more above or below us so move that way.
                if (distY < 0)
                {
                    //Player is above
                    //Check to see if there is no wall in that direction
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x), (int)(transform.position.y+1f), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        //There is no wall in that direction
                        transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                    } else
                    {
                        //I cannot go up because there is a wall so now check to go left or right
                        if (distX < 0)
                        {
                            //Player is to the right
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x + 1f), (int)(transform.position.y), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                        else if (distX >= 0)
                        {
                            //Player is to the left
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x - 1f), (int)(transform.position.y), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                    }
                }
                else if (distY >= 0)
                {
                    //Player is below
                    //Check to see if there is no wall in that direction
                    Vector3Int targetCell = new Vector3Int((int)(transform.position.x), (int)(transform.position.y-1f), 0);
                    bool hasWall = wallsMap.GetTile(targetCell) != null;

                    if (!hasWall)
                    {
                        //There is no wall in that direction
                        transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                    } else
                    {
                        //I cannot go down because there is a wall so now check to go left or right
                        if (distX < 0)
                        {
                            //Player is to the right
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x + 1f), (int)(transform.position.y), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                        else if (distX >= 0)
                        {
                            //Player is to the left
                            //Check to see if there is no wall in that direction
                            targetCell = new Vector3Int((int)(transform.position.x - 1f), (int)(transform.position.y), 0);
                            hasWall = wallsMap.GetTile(targetCell) != null;

                            if (!hasWall)
                            {
                                //There is no wall in that direction
                                transform.position = Vector3.MoveTowards(transform.position, targetCell, 4 * Time.deltaTime);
                            }
                        }
                    }
                }
            }
        }

    }
}
