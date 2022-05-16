using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Animator animator;
    private float rotateSpeed=2f;
    CharacterController characterController;

    //public Button play;;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
       // play.onClick.AddListener(Jump);
    }

    public void Jump()
    {
        // transform.Translate(Vector3.up * speed);
       
    }

    // Update is called once per frame
    void Update()
    {
      
        Player();
    }

    public void Player()
    {
        float inputX = Input.GetAxis("Horizontal") * speed;        //Movement of the player in horizontal direction
        float inputZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(inputX * Time.deltaTime, 0f, inputZ * Time.deltaTime);
        animator.SetFloat("Speed", movement.magnitude);
        transform.Rotate(Vector3.up, inputX * rotateSpeed * Time.deltaTime);
        if (inputZ != 0)
        {
            characterController.SimpleMove(transform.forward * Time.deltaTime * inputZ);
        }
    }
}
