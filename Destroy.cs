using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyObject", 5f);
    }

    private void DestroyObject()
    {
        Destroy(this);
    }
}
