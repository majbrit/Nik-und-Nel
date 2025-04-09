using UnityEngine;
using UnityEngine.XR;

public class ThirdPersonController : MonoBehaviour
{

    public float moveSpeed = 3.0f;
    public float turnSpeed = 10.0f;
    public Transform cameraTransform; // Referenz zur Kamera im XR Origin

    public CharacterController characterController;

    void Start()
    {

    }

    void Update()
    {

        Vector2 leftInput = GetControllerInputLeft();
        Vector2 rightInput = GetControllerInputRight();

        Vector3 moveDirection = cameraTransform.forward * leftInput.y + cameraTransform.right * leftInput.x;
        moveDirection.y = 0f; 
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);


        float rotationInput = rightInput.x;
        if (Mathf.Abs(rotationInput) > 0.1f)
        {
            float rotationAmount = rotationInput * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount); 
        }
    }

    Vector2 GetControllerInputLeft()
    {
        var leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 input))
        {
            return input; 
        }
        return Vector2.zero; 
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
}
