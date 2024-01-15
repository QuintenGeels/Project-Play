using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    private static Load instance;

    void Awake()
    {
        Debug.Log("Awake called");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.Log("OnDisable called");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded called for scene: " + scene.name);

        // Check if the current scene is 9 or 10 and destroy the GameObject
        if (scene.name == "Lose" || scene.name == "Win")
        {
            Debug.Log("Destroying GameObject in Scene 9 or 10");
            Destroy(gameObject);
        }
        // Perform setup or cleanup actions for the new scene
    }
}