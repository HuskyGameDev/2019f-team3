using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrashDrop : MonoBehaviour
{
    public GameObject trashPrefab;
    public Tilemap wallsMap;

    private Vector3 position;

    private int zVal;

    private void Start()
    {
        zVal = wallsMap.origin.z;
    }

    public void DropAPiece(Vector3 currentPos)
    {
        position = currentPos;
        Vector3 dropPlace = FindOpenTileForObject();
        Instantiate(trashPrefab, dropPlace, Quaternion.identity);
    }
    
    private Vector3 FindOpenTileForObject()
    {
        Vector3Int targetCell;
        bool hasWall;

        Collider2D[] results;

        for (int i = 1; i < 4; i++)
        {
            // THE FOUR INITIAL DIRECTIONS
            targetCell = new Vector3Int((int)(position.x - i - 0.5f), (int)(position.y - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x - i, position.y), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x - i, position.y, position.z);
                }
            }

            targetCell = new Vector3Int((int)(position.x + i - 0.5f), (int)(position.y - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x + i, position.y), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x + i, position.y, position.z);
                }
            }

            targetCell = new Vector3Int((int)(position.x - 0.5f), (int)(position.y - i - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x, position.y - i), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x, position.y - i, position.z);
                }
            }

            targetCell = new Vector3Int((int)(position.x - 0.5f), (int)(position.y + i - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x, position.y + i), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x, position.y + i, position.z);
                }
            }


            // THE CORNERS

            targetCell = new Vector3Int((int)(position.x - i - 0.5f), (int)(position.y - i - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x - i, position.y - i), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x - i, position.y - i, position.z);
                }
            }

            targetCell = new Vector3Int((int)(position.x + i - 0.5f), (int)(position.y - i - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x + i, position.y - i), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x + i, position.y - i, position.z);
                }
            }


            targetCell = new Vector3Int((int)(position.x - i - 0.5f), (int)(position.y + i - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x - i, position.y + i), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x - i, position.y + i, position.z);
                }
            }


            targetCell = new Vector3Int((int)(position.x + i - 0.5f), (int)(position.y + i - 0.5f), zVal);

            hasWall = wallsMap.GetTile(targetCell) != null;

            if (!hasWall)
            {
                results = Physics2D.OverlapCircleAll(new Vector2(position.x + i, position.y + i), 0.5f);
                if (results.Length == 0)
                {
                    return new Vector3(position.x + i, position.y + i, position.z);
                }
            }


            // THE REST


            for (int k = 1; k < i; k++)
            {
                targetCell = new Vector3Int((int)(position.x - i - 0.5f), (int)(position.y - k - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x - i, position.y - k), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x - i, position.y - k, position.z);
                    }
                }
                // ************************************************************************************

                targetCell = new Vector3Int((int)(position.x + i - 0.5f), (int)(position.y - k - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x + i, position.y - k), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x + i, position.y - k, position.z);
                    }
                }
                // ************************************************************************************

                targetCell = new Vector3Int((int)(position.x - i - 0.5f), (int)(position.y + k - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x - i, position.y + k), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x - i, position.y + k, position.z);
                    }
                }
                // ************************************************************************************

                targetCell = new Vector3Int((int)(position.x + i - 0.5f), (int)(position.y + k - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x + i, position.y + k), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x + i, position.y + k, position.z);
                    }
                }
                // ************************************************************************************

                targetCell = new Vector3Int((int)(position.x - k - 0.5f), (int)(position.y - i - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x - k, position.y - i), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x - k, position.y - i, position.z);
                    }
                }
                // ************************************************************************************

                targetCell = new Vector3Int((int)(position.x + k - 0.5f), (int)(position.y - i - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x + k, position.y - i), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x + k, position.y - i, position.z);
                    }
                }
                // ************************************************************************************

                targetCell = new Vector3Int((int)(position.x - k - 0.5f), (int)(position.y + i - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x - k, position.y + i), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x - k, position.y + i, position.z);
                    }
                }
                // ************************************************************************************

                targetCell = new Vector3Int((int)(position.x + k - 0.5f), (int)(position.y + i - 0.5f), zVal);

                hasWall = wallsMap.GetTile(targetCell) != null;

                if (!hasWall)
                {
                    results = Physics2D.OverlapCircleAll(new Vector2(position.x + k, position.y + i), 0.5f);
                    if (results.Length == 0)
                    {
                        return new Vector3(position.x + k, position.y + i, position.z);
                    }
                }
            }
        }

        return position;
    }
}
