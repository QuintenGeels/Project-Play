using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public void speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * xInput * speed * Time.deltaTime);

        float yInput = Input.GetAxis("Vertical");
        transform.Translate(vector2.up * yInput * speed * Time.deltaTime);
    }
}