
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControler : MonoBehaviour
{
    Rigidbody2D body;

    public float runSpeed = 3.0f;
    public float moveCooldown = 0.2f;
    public int bagSize = 10;

    public Tilemap groundMap;
    public Tilemap wallsMap;

    private int trashBag = 0;
    private bool isMoving = false;
    private bool onCooldown = false;
    private bool letsMove = false;

    private Vector2 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //Freeze rotation
        body.freezeRotation = true;
    }

    void Update()
    {
        if (isMoving || onCooldown) return;

        Vector2 currentKeys = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (currentKeys != Vector2.zero)
        {
            movement = currentKeys;
            letsMove = true;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving || onCooldown || !letsMove) return;

        if (!movement.x.Equals(0.0f))
        {
            movement.y = 0.0f;
        }

        if (moveCooldown > 0f)
        {
            StartCoroutine(MovementCooldown(moveCooldown));
        }
        Move(movement.x, movement.y);
    }

    private void Move(float xDir, float yDir)
    {

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x + xDir, startPos.y + yDir, startPos.z);

        Vector3Int targetCell = new Vector3Int((int)(endPos.x - 0.5f), (int)(endPos.y - 0.5f), (int)endPos.z);

        bool hasWall = wallsMap.GetTile(targetCell) != null;

        movement = Vector2.zero;
        letsMove = false;

        if (!hasWall)
        {
            StartCoroutine(SmoothMove(startPos, endPos));
        }
    }

    private IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos)
    {
        isMoving = true;

        float progress = 0.0f;

        do
        {
            progress += Time.deltaTime * runSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, progress);

            yield return null;
        } while (progress < 1f);

        transform.position = endPos;

        isMoving = false;
    }

    private IEnumerator MovementCooldown(float cooldown)
    {
        onCooldown = true;

        while (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
            yield return null;
        }

        onCooldown = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            if (trashBag < bagSize)
            {
                trashBag += 1;
                Destroy(collision.gameObject);
            }
        } else if (collision.gameObject.tag == "Dumpster")
        {
            GameManager.gm.Collect(trashBag);
            trashBag = 0;
        }
    }
}