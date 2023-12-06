using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float yInput = 0f;
    public float xInput = 0f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private enum MovementState { idle, walkingUp, walkingDown, walkingLeft, walkingRight}
    private MovementState State = MovementState.idle;



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
    }

    void Move()
    {
        xInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * xInput * speed * Time.deltaTime);

        yInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * yInput * speed * Time.deltaTime);


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
        else
        {
            State = MovementState.idle;
        }
        if (xInput > 0f)
        {
            State = MovementState.walkingLeft;
        }
        else if (xInput < 0f)
        {
            State = MovementState.walkingRight;
        }
        else
        {
            State = MovementState.idle;
        }

        Debug.Log(State);

        anim.SetInteger("State", (int)State);
    }
}