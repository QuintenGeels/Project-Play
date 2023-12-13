using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    [SerializeField] private Transform PauseBackground;
    [SerializeField] private Transform Opacity;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    // Check for input in LateUpdate to ensure camera has moved before pausing
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("hello");
            // Move the background position to the center of the camera
            MoveBackgroundToCameraCenter();
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
}