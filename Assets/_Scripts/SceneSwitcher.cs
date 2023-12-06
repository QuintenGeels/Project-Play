using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // The name of the scene you want to switch to
    public string targetSceneName;
    public bool quitButton = false;

    private void OnMouseDown()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
        }
        if (Input.GetMouseButtonDown(0) && quitButton)
        {
            // Quit the application
            Application.Quit();
            Debug.Log("quited");
        }
    }
}