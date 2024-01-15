using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class DropPoint : MonoBehaviour
{
    public string collisionTag;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UnityEngine.SceneManagement.Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneIndex = activeScene.buildIndex;
        ToggleRenderer(activeSceneIndex != 0 && activeSceneIndex != 1 && activeSceneIndex != 3 && activeSceneIndex != 9 && activeSceneIndex != 10);
    }
    void ToggleRenderer(bool isVisible)
    {
        if (sprite != null)
        {
            // Set the visibility of the SpriteRenderer based on the condition
            sprite.enabled = isVisible;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit GameObject");

        if (collision.gameObject.CompareTag(collisionTag ))
        {
            Destroy(this.gameObject);
        }
    }
}
