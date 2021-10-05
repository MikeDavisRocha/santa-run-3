using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFloor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("EndPosition"))
        {
            collision.transform.parent.gameObject.SetActive(false);
            HideAllSprites(collision);
            collision.transform.parent.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
        }        
    }

    private void HideAllSprites(Collision2D col)
    {
        SpriteRenderer[] sprites =  col.transform.parent.gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in sprites)
        {
            s.enabled = false;
        }
    }
}
