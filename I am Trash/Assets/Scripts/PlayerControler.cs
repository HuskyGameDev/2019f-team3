using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

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
        if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical)) {
            body.velocity = new Vector2(horizontal * runSpeed, 0.0f);
        } else {
            body.velocity = new Vector2(0.0f, vertical * runSpeed);
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
