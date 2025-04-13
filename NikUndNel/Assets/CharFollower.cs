using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class CharFollower : MonoBehaviour
{
    public GameObject character;
    public Vector3 offsetCharCam = new Vector3(2, 0, 0f);
    public float smoothTime = 0.3f;


    public float currentAngle = 0f;
    public float rotationSpeed = 100f;
    public float radius = 2f;

    private void Update()
    {

    // move camera
    Vector2 rightInput = GetControllerInputRight();
        float rotationInput = rightInput.x;
        if (Mathf.Abs(rotationInput) > 0.1f)
        {
            currentAngle += rotationInput * rotationSpeed * Time.deltaTime;

            float angleRad = currentAngle * Mathf.Deg2Rad;
            offsetCharCam = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad)) * radius;
        }
    }

    Vector2 GetControllerInputRight()
    {
        var leftHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (leftHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 input))
        {
            return input;
        }
        return Vector2.zero;
    }

    private void LateUpdate()
    {

        transform.position = character.transform.position + offsetCharCam;
        transform.LookAt(character.transform);

    }
}
