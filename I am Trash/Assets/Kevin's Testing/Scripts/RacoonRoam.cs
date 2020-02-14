using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RacoonRoam : MonoBehaviour
{
    public Tilemap groundMap;
    public Tilemap wallsMap;

    public GameObject player;

    public float vision = 0.25f;
    public int delayTime = 5;
    private int delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ( delay <= 0 )
        {
            //-----------------------------------------------------------------------------------------------------------------------------------------
            //Checking to see if player is close by
            float dist = Vector2.Distance(player.transform.position, transform.position);
            if (dist < 0)
            {
                dist = dist * -1;
            }

            if (dist <= 6)
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
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x + 0.5f), (int)(transform.position.y), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go right
                            Vector3 target = new Vector3(transform.position.x + 0.5f, transform.position.y, 0);
                            transform.position = Vector3.MoveTowards(transform.position, target, 4 * Time.deltaTime);
                        }
                    }
                    else
                    {
                        //The player is to the left, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.5f), (int)(transform.position.y), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go right
                            Vector3 target = new Vector3(transform.position.x - 0.5f, transform.position.y, 0);
                            transform.position = Vector3.MoveTowards(transform.position, target, 4 * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    if (distY < 0)
                    {
                        //The player is above, check for a wall
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x + 0.0f), (int)(transform.position.y + 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go up
                            Vector3 target = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
                            transform.position = Vector3.MoveTowards(transform.position, target, 4 * Time.deltaTime);
                        }
                    }
                    else
                    {
                        //The player is below
                        Vector3Int targetCell = new Vector3Int((int)(transform.position.x - 0.0f), (int)(transform.position.y - 0.5f), 0);
                        bool hasWall = wallsMap.GetTile(targetCell) != null;

                        if (!hasWall)
                        {
                            //Ther is no wall, go down
                            Vector3 target = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
                            transform.position = Vector3.MoveTowards(transform.position, target, 4 * Time.deltaTime);
                        }
                    }
                }
            }
            //-----------------------------------------------------------------------------------------------------------------------------------------
        }
        else
        {
            delay--;
        }
    }
}
