using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedTrashBagScript : MonoBehaviour
{
    public GameObject player;
    public float effectLength;

    private PlayerControler controler;

    private int trashbag;

    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        controler = player.GetComponent<PlayerControler>();
    }

    public void PickUpUnlimited()
    {
        trashbag = controler.bagSize;

        controler.bagSize = int.MaxValue;

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        float time = 0f;

        while (time < effectLength)
        {
            time += Time.deltaTime;
            yield return null;
        }

        controler.bagSize = trashbag;

        if (controler.GetTrashBag() > trashbag)
        {
            GameManager.gm.DropTrash(controler.GetTrashBag() - trashbag, controler.transform.position);
            controler.SetTrashBag(trashbag);
        }
    }
}
