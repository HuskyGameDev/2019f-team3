
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControler : MonoBehaviour
{
    Rigidbody2D body;

    public float runSpeed = 5.0f;
    public int bagSize = 10;

    public Tilemap wallsMap;

    private int trashBag;
    private bool isMoving;
    private bool letsMove;

    private Vector2 movement;

    private int zVal;

    private float progress;

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //Freeze rotation
        body.freezeRotation = true;

        zVal = wallsMap.origin.z;

        isMoving = false;
    }

    void Update()
    {
        if (!isMoving || progress > 0.8f)
        {
            Vector2 currentKeys = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if (currentKeys != Vector2.zero)
            {
                movement = currentKeys;
                letsMove = true;
            }
        }

        if (!isMoving && letsMove)
        {
            if (!movement.x.Equals(0.0f))
            {
                movement.y = 0.0f;
            }

            startPos = transform.position;
            endPos = new Vector3(startPos.x + movement.x, startPos.y + movement.y, startPos.z);

            Vector3Int targetCell = new Vector3Int((int)(endPos.x - 0.5f), (int)(endPos.y - 0.5f), zVal);

            bool hasWall = wallsMap.GetTile(targetCell) != null;

            movement = Vector2.zero;
            letsMove = false;

            if (!hasWall)
            {
                isMoving = true;
            }
        }

        if (isMoving)
        {
            progress += Time.deltaTime * runSpeed;
            
            if (progress < 0.95f)
            {
                transform.position = Vector3.Lerp(startPos, endPos, progress);
            } else {
                transform.position = Vector3.Lerp(startPos, endPos, 1f);
                isMoving = false;
                progress = 0f;
            }
        }
    }

    public int GetTrashBag()
    {
        return trashBag;
    }

    public void SetTrashBag(int trash)
    {
        trashBag = trash;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Debug.Log("I picked up some trash");
            if (trashBag < bagSize)
            {
                trashBag += 1;
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Dumpster")
        {
            GameManager.gm.Collect(trashBag);
            trashBag = 0;
        } else if (collision.gameObject.tag == "Enemy")
        {
            if ( trashBag > 0 )
            {
                Debug.Log("The racoon took your trash!");
                trashBag--;
            }
        }
    }
}