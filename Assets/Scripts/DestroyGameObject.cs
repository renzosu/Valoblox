using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float timeToDestroy = 2;

    void Start()
    {
        Invoke("DestroyThisObject", timeToDestroy);
    }

    void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
