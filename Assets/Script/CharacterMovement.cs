using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Basic Movement")]
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;
    private float velocity = 2f;
    
    void Start()
    {
        //BasicMovement
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //BasicMovement
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(inputs * Time.deltaTime * velocity);
        character.Move(Vector3.down * Time.deltaTime);

        //Animations Walking
        if (inputs != Vector3.zero)
        {
            animator.SetBool("walking", true);
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
}
