//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    private bool isPaused = false;
    public Transform target;
    [SerializeField] private Transform PauseBackground;
    [SerializeField] private Transform Opacity;

    private static CameraFollow instance;
    private bool stopFollowing = false;



    // Update is called once per frame
    void Update()
    {
        if (!stopFollowing)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
        
        
            
        

        UnityEngine.SceneManagement.Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneIndex = activeScene.buildIndex;

        switch (activeSceneIndex)
        {
            case 0:
                stopFollowing = true;
                //transform.position = new Vector3(0f, 0f, 0f);
                break;
            case 1:                
                stopFollowing = true;
                //transform.position = new Vector3(0f, 0f, 0f);
                Destroy(gameObject);
                break;
            case 2:
                stopFollowing = false;
                //transform.position = new Vector3(-2.21f, -1.44f, 0);
                break;
            case 3:
                stopFollowing = true;
                //transform.position = new Vector3(0f, 0f, 0f);
                break;
            case 4:
                stopFollowing = false;
                //transform.position = new Vector3(-2, 1.5f, 0);
                break;
            case 5:
                stopFollowing = false;
                //transform.position = new Vector3(0f, 0f, 0f);
                break;
            case 6:
                stopFollowing = false;
                //transform.position = new Vector3(3.5f, -4, 0);
                break;
            case 7:
                stopFollowing = false;
                //transform.position = new Vector3(-4, 2.5f, 0);
                break;
            case 8:
                stopFollowing = false;
                //transform.position = new Vector3(-6, 0, 0);
                break;
            case 9:
                stopFollowing = true;
                //transform.position = new Vector3(0f, 0f, 0f);
                break;
            case 10:
                stopFollowing = true;
                //transform.position = new Vector3(0f, 0f, 0f);
                break;            
        }

        // Now you can use activeSceneIndex as needed.
        Debug.Log("Active Scene Index: " + activeSceneIndex);
    }

    // Check for input in LateUpdate to ensure camera has moved before pausing
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                PauseBackground.transform.position = new Vector3(200, 0, 0);
                Opacity.transform.position = new Vector3(200, 0, 0);
                isPaused = false;

            }
            else
            {
                MoveBackgroundToCameraCenter();
                isPaused = true;
            }
        }
    }

    // Move the background position to the center of the camera
    private void MoveBackgroundToCameraCenter()
    {
        if (PauseBackground != null)
        {
            Camera mainCamera = Camera.main;

            if (mainCamera != null)
            {
                Vector3 cameraCenter = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane));
                PauseBackground.transform.position = cameraCenter;
                Opacity.transform.position = cameraCenter;
            }
            else
            {
                Debug.LogWarning("Main camera not found.");
            }
        }
        
    }
    void Awake()
    {
        if (instance == null)
        {
            // If no instance exists, make this the instance and mark it to not be destroyed on scene load
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }
}