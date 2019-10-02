using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 5.0f;
    public float trashSlows = 0.0f;

    private int trashBag = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // Moves slower with more trash
        float speed = runSpeed * (1 - (trashBag * trashSlows));

        if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical)) {
            body.velocity = new Vector2(horizontal * speed, 0.0f);
        } else {
            body.velocity = new Vector2(0.0f, vertical * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            trashBag += 1;
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Dumpster")
        {
            GameManager.gm.Collect(trashBag);
            trashBag = 0;
        }
    }
}
