using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.WSA;

public class SceneSwitcher : MonoBehaviour
{
    // The index of the scene you want to switch to
    public int targetSceneIndex;
    
    // Reference to the GameObject you want to destroy
    public GameObject targetGameObject;
    public bool quitButton = false;
    public bool startScene = true;




    private void OnMouseDown()
    {
        // Assuming boolValue is your boolean variable
        if (startScene)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(targetSceneIndex);
            }
        }
        else
        {
            // Check if the left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                GameObject player = GameObject.FindWithTag("Player");

                // Load the target scene by index
                switch (targetSceneIndex)
                {
                    case 2:
                        player.transform.position = new Vector3(-2.21f, -1.44f, 0);
                        break;
                    case 4:
                        player.transform.position = new Vector3(-2, 1.5f, 0);
                        break;
                    case 5:
                        player.transform.position = new Vector3(-5.32f, 2.26f, 0);
                        break;
                    case 6:
                        player.transform.position = new Vector3(3.5f, -4, 0);
                        break;
                    case 7:
                        player.transform.position = new Vector3(-4, 2.5f, 0);
                        break;
                    case 8:
                        player.transform.position = new Vector3(-6, 0, 0);
                        break;
                }
                SceneManager.LoadScene(targetSceneIndex);
            }
        }
        if (Input.GetMouseButtonDown(0) && quitButton)
        {
            // Quit the application
            Application.Quit();
            Debug.Log("Quited");
        }
    }      
}