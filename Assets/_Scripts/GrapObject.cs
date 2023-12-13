using TMPro;
using UnityEngine;

public class GrapObject : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private Transform playerCenter;
    [SerializeField] private float rayDistance;
    [SerializeField] private TextMeshProUGUI popupText;

    private GameObject grabbedObject;
    private int layerIndex;
    private bool facingRight = true;
    public float boxDistance = 0.6f;

    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        popupText.gameObject.SetActive(false);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right * (facingRight ? 1 : -1), Mathf.Abs(rayDistance));

        if ((hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex) || grabbedObject)
        {
            if (!grabbedObject && Vector2.Distance(transform.position, hitInfo.collider.gameObject.transform.position) < boxDistance) 
            {
                popupText.gameObject.SetActive(true);
            }
            else
            {
                popupText.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E) && !grabbedObject)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
                popupText.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
        else
        {
            popupText.gameObject.SetActive(false);
        }

        Debug.DrawRay(rayPoint.position, transform.right * (facingRight ? 1 : -1) * Mathf.Abs(rayDistance), Color.red);

        if (horizontalInput < 0 && facingRight)
        {
            FlipCharacter();
            rayDistance *= -1;
        }
        else if (horizontalInput > 0 && !facingRight)
        {
            FlipCharacter();
            rayDistance *= -1;
        }

        if (grabbedObject != null)
        {
            Vector3 newPosition = transform.position + (facingRight ? transform.right : -transform.right) * boxDistance;
            grabbedObject.transform.position = newPosition;
        }

        IdleCharacter(verticalInput);
    }

    void IdleCharacter(float verticalInput)
    {
        if (verticalInput > 0 && grabbedObject != null || verticalInput < 0 && grabbedObject != null)
        {
            Vector3 newPosition = playerCenter.position;
            grabbedObject.transform.position = newPosition;
        }
    }

    void FlipCharacter()
    {
        facingRight = !facingRight;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }
}