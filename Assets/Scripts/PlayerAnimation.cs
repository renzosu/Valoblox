using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float speed;
    private float horizontalSpeed;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        AnimatePlayer();
    }

    private void AnimatePlayer()
    {
        speed = Input.GetAxis("Vertical");
        horizontalSpeed = Input.GetAxis("Horizontal");

        animator.SetFloat("speed", speed);
        animator.SetFloat("horizontal speed", horizontalSpeed);
    }
}
