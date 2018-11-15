﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseDraft : MonoBehaviour {
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

	// Use this for initialization
	void Start () {
        LockCursor();
        xAxisClamp = 0;
	}
    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }
	// Update is called once per frame
	void Update () {
        CameraRotation();
	}
    private void CameraRotation() {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity *Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(-270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(-90.0f);
        }

        transform.Rotate(Vector3.right * mouseY);
        playerBody.Rotate(Vector3.down * mouseX);
    }

    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
