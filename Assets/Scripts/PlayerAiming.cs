﻿using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [Header("References")]
    public Transform bodyTransform;

    [Header("Sensitivity")]
    public float sensitivityMultiplier = 1f;
    public float horizontalSensitivity = 1f;
    public float verticalSensitivity = 1f;

    [Header("Restrictions")]
    public float minYRotation = -90f;
    public float maxYRotation = 90f;

    private Vector3 realRotation;

    [Header("Aimpunch")]
    public float punchDamping = 9.0f;
    public float punchSpringConstant = 65.0f;

    [HideInInspector]
    public Vector2 punchAngle;

    [HideInInspector]
    public Vector2 punchAngleVel;

    private void Start()
    {
        // Lock the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetComponent<Camera>().nearClipPlane = 0.01f;
    }

    private void Update()
    {
        // Fix pausing
        if (Mathf.Abs(Time.timeScale) <= 0)
        {
            return;
        }
        DecayPunchAngle();

        // Input
        float xMovement = Input.GetAxisRaw("Mouse X") * horizontalSensitivity * sensitivityMultiplier;
        float yMovement = -Input.GetAxisRaw("Mouse Y") * verticalSensitivity * sensitivityMultiplier;

        // Calculate real rotation from input
        realRotation = new Vector3(Mathf.Clamp(realRotation.x + yMovement, minYRotation, maxYRotation), realRotation.y + xMovement, realRotation.z);


        //Apply rotation to body
        Vector3 rotationVector = new Vector3(0f, 1f,0f);
        bodyTransform.eulerAngles = Vector3.Scale(realRotation, rotationVector);


        //Apply rotation and recoil
        Vector3 cameraEulerPunchApplied = realRotation;
        cameraEulerPunchApplied.x += punchAngle.x;
        cameraEulerPunchApplied.y += punchAngle.y;

        transform.eulerAngles = cameraEulerPunchApplied;
    }

    public void ViewPunch(Vector2 punchAmount)
    {
        //Remove previous recoil
        punchAngle = Vector2.zero;

        //Recoil go up
        punchAngleVel -= punchAmount * 20;
    }
    private void DecayPunchAngle()
    {
        if (punchAngle.sqrMagnitude > 0.001 || punchAngleVel.sqrMagnitude > 0.001)
        {
            punchAngle += punchAngleVel * Time.deltaTime;
            float damping = 1 - (punchDamping * Time.deltaTime);

            if (damping < 0)
            {
                damping = 0;
            }

            punchAngleVel *= damping;

            float springForceMagnitude = punchSpringConstant * Time.deltaTime;
            punchAngleVel -= punchAngle * springForceMagnitude;
        }
        else
        {
            punchAngle = Vector2.zero;
            punchAngleVel = Vector2.zero;
        }
    }
}