using UnityEngine;
using UnityEngine.SceneManagement;

public class Bar : MonoBehaviour
{
    public RectTransform bar;
    public int time;
    public int scaleSize;
    [SerializeField] private Transform gameBar;

    private bool isAnimationStopped = false;

    void Start()
    {
        AnimateBar();
        gameBar.transform.position = new Vector3(20, 0, 0);
    }

    private void Update()
    {
        UnityEngine.SceneManagement.Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneIndex = activeScene.buildIndex;

        // Check if the bar has reached zero and the current scene is not 9
        if (bar.localScale.x <= 0 && activeSceneIndex != 9)
        {
            // Check if the current scene is 2, 4, 5, 6, 7, or 8
            if (activeSceneIndex == 2 || activeSceneIndex == 4 || activeSceneIndex == 5 || activeSceneIndex == 6 || activeSceneIndex == 7 || activeSceneIndex == 8)
            {
                SceneManager.LoadScene(9);
            }
        }

        GameObject Box = GameObject.FindWithTag("Box");

        if ((activeSceneIndex == 10 || activeSceneIndex == 9) && !isAnimationStopped)
        {
            // Stop the LeanTween animation
            Destroy(this.gameObject);
            // Optionally, you can add additional logic here if needed.

            isAnimationStopped = true;
        }
        else if (activeSceneIndex == 2)
        {
            // Reset the animation when in scene 2
            AnimateBar();
            isAnimationStopped = false;
        }
    }

    public void AnimateBar()
    {
        RectTransform rectTransform = bar.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0f, rectTransform.pivot.y);

        // Use bar.gameObject for the LeanTween method
        LeanTween.scaleX(bar.gameObject, 0, time).setEase(LeanTweenType.easeOutQuad);
    }
}