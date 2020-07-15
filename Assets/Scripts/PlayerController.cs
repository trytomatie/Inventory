using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    private Vector2 movementDirection;
    private Rigidbody2D _rb;
    private Transform _transform;
    private Animator _anim;
    public InteractionRadius interactionRadius;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>    
    void Start()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        Movement();
        Interact();
    }



    /// <summary>
    /// Handles the movement input
    /// </summary>
    private void Movement()
    {
        int x = 0;
        int y = 0;

        // Reading Input
        if(Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }

        // Set velocity
        _rb.velocity = new Vector2(x, y) * movementSpeed;

        // Update Animations
        UpdateMovementAnimations(x,y);
    }

    /// <summary>
    /// Handles the interaction input
    /// </summary>
    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionRadius.target.Interact(gameObject);
        }
    }

    /// <summary>
    /// Updates the movement Animations
    /// </summary>
    private void UpdateMovementAnimations(int x,int y)
    {
        // Check if the player is moving
        bool isMoving = (x == 0 && y == 0) ? false : true;
        if(isMoving)
        {
            if (x != 0)
                _anim.SetFloat("MoveDirX", x);

            _anim.SetFloat("MoveDirY", y);
        }
        _anim.SetBool("IsMoving", isMoving);

    }
}
