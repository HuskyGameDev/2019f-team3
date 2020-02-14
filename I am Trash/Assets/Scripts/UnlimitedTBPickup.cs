using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedTBPickup : MonoBehaviour
{
    public GameObject objectManagers;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnlimitedTrashBagScript trashScript = objectManagers.GetComponent<UnlimitedTrashBagScript>();
            trashScript.PickUpUnlimited();
            Destroy(gameObject);
        }
    }
}
