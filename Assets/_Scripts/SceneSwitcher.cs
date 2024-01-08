using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // The index of the scene you want to switch to
    public int targetSceneIndex;
    // Reference to the GameObject you want to destroy
    public GameObject targetGameObject;
    public bool quitButton = false;

    

    private void OnMouseDown()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
                       

            // Load the target scene by index
            SceneManager.LoadScene(targetSceneIndex);
        }

        if (Input.GetMouseButtonDown(0) && quitButton)
        {
            // Quit the application
            Application.Quit();
            Debug.Log("Quited");
        }
    }
}