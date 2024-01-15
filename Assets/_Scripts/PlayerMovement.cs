using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    public float yInput = 0f;
    public float xInput = 0f;
    private bool isPaused = false;
    public int points = 0;
    public int winCondition;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private enum MovementState { idle, walkingUp, walkingDown, walkingLeft, walkingRight }
    private MovementState State = MovementState.idle;
    HashSet<string> validTags = new HashSet<string> { "Liver", "Heart", "Intestines", "Muscles", "Lungs" };


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateAnimationUpdate();
        gamePause();
        UnityEngine.SceneManagement.Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneIndex = activeScene.buildIndex;
        ToggleRenderer(activeSceneIndex != 0 && activeSceneIndex != 1 && activeSceneIndex != 3 && activeSceneIndex != 9 && activeSceneIndex != 10);
        if (activeSceneIndex == 9 || activeSceneIndex == 10) 
        {
            Destroy(gameObject);
        }
    }

    // Function to toggle the SpriteRenderer based on a condition
    void ToggleRenderer(bool isVisible)
    {
        if (sprite != null)
        {
            // Set the visibility of the SpriteRenderer based on the condition
            sprite.enabled = isVisible;
        }
    }

    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit GameObject");

        if (validTags.Contains(collision.gameObject.tag))
        {
            points++;
            if (points >= winCondition)
            {
                SceneManager.LoadScene(10);
            }
        }
    }
    void Move()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (!isPaused)
        {
            // Only move if the player is allowed to move
            if (CanMove())
            {
                transform.Translate(Vector2.right * xInput * speed * Time.deltaTime);
                transform.Translate(Vector2.up * yInput * speed * Time.deltaTime);
            }
        }
    }

    bool CanMove()
    {
        // Check if the player is allowed to move based on your conditions
        return !isPaused && !Input.GetKey(KeyCode.Escape);
    }

    void gamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle pause state
            isPaused = !isPaused;

            if (isPaused)
            {
                // Pause the game
                Time.timeScale = 0f;
                speed = 0f;
            }
            else
            {
                // Resume the game
                Time.timeScale = 1f;
                speed = 5f;
            }
        }
    }

    private void UpdateAnimationUpdate()
    {
        if (yInput > 0f)
        {
            State = MovementState.walkingUp;
        }
        else if (yInput < 0f)
        {
            State = MovementState.walkingDown;
        }
        else if (xInput > 0f)
        {
            State = MovementState.walkingRight;
        }
        else if (xInput < 0f)
        {
            State = MovementState.walkingLeft;
        }
        else
        {
            State = MovementState.idle;
        }

        anim.SetInteger("State", (int)State);
    }
}