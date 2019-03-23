using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float sprintSpeed;

    public CharacterController characterCont;

    public float characterHeight;
    Vector3 crouchMoveSpeed;
    public AudioSource aud;
    private bool audioPlaying = false;

    private CharacterController characterController;

    public Transform YJumpHeight;
    public float newYValue;
    private bool IsInAir;
    private bool wasdPressed = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start()
    {
        characterCont.GetComponent<CharacterController>();
        YJumpHeight.GetComponent<Transform>();
        aud.GetComponent<AudioSource>();

        InvokeRepeating("checkJumpHeight", 5.0f, 3.0f);
        aud.mute = !aud.mute;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();

    }

    void checkJumpHeight()
    {
        //Debug.Log(gameObject.transform.position.y);
    }

    private void PlayerMovement()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed * 2;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)) {
            movementSpeed = movementSpeed / 2;
        }

        float horizInput = Input.GetAxis(verticalInputName) * movementSpeed * Time.deltaTime;
        float vertInput = Input.GetAxis(horizontalInputName) * movementSpeed * Time.deltaTime;

        float horizSprintInput = Input.GetAxis(verticalInputName) * sprintSpeed * Time.deltaTime;

        Vector3 forwardmovement = transform.forward * horizInput;
        Vector3 rightMovement = transform.right * vertInput;

        characterController.SimpleMove(forwardmovement);
        characterController.SimpleMove(rightMovement);

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            characterCont.height += -10f;
            movementSpeed = -500;
            sprintSpeed = -500;
            crouchMoveSpeed = new Vector3(movementSpeed, movementSpeed, movementSpeed);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl)) {
            characterCont.height += 10f;
            movementSpeed = -1000;
            
        }
        if(characterCont.height == 15) {
            characterCont.height += 0;
        }
        if(characterCont.height == 30) {
            characterCont.height += 0;
        }


        /*if(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")) {
            aud.mute = !aud.mute;
        }

        if (audioPlaying == true && wasdPressed) {
            aud.Play();
        }

        if (Input.GetKeyUp("w") && Input.GetKeyUp("s") && Input.GetKeyUp("a") && Input.GetKeyUp("d"))
        {
            aud.Stop();
            audioPlaying = false;
            wasdPressed = true;
        }
        */









        /*if (Input.GetKeyDown("w") && Input.GetKeyDown(KeyCode.LeftShift)) {
            Vector3 sprintforward = transform.forward * horizSprintInput; 
            characterController.SimpleMove(sprintforward);

        }*/

        /* if (Input.GetKeyDown(KeyCode.Space) && transform.position.y >= 15) {
            newYValue = newYValue + 1 + transform.position.y;
            transform.position = new Vector3(transform.position.x, newYValue, transform.position.y);
            IsInAir = true;

            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsInAir = false;
                newYValue = newYValue - 1 - transform.position.y;
            }
        } */




    }



}