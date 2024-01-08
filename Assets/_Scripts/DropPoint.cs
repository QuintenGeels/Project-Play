using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour
{
    public string collisionTag = "Box"; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit GameObject");

        if (collision.gameObject.CompareTag(collisionTag))
        {
            Destroy(this.gameObject);
        }
    }
}
