using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time;
    [SerializeField] private Transform gameBar;

    void Start()
    {
        AnimateBar();
        gameBar.transform.position = new Vector3(20, 0, 0);
    }

    public void AnimateBar()
    {
        RectTransform rectTransform = bar.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0f, rectTransform.pivot.y); // Set pivot to the right

        LeanTween.scaleX(bar, 0, time).setEase(LeanTweenType.easeOutQuad); // Scale down to 0
    }
}