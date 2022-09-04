using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    public Sprite spriteIten;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player1"))
        {
            GameManagerScript.instance.isP1GetItem = true;
            GameManagerScript.instance.imgP1Item.sprite = spriteIten;
        }
        if (collision.name.Equals("Player2"))
        {
            GameManagerScript.instance.isP2GetItem = true;
            GameManagerScript.instance.imgP2Item.sprite = spriteIten;
        }
        gameObject.SetActive(false);
    }
}
