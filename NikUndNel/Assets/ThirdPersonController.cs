using UnityEngine;
using UnityEngine.XR;

public class ThirdPersonController : MonoBehaviour
{

    public float moveSpeed = 3.0f;
    public float turnSpeed = 10.0f;
    public Transform cameraTransform; 

    public CharacterController characterController;

    void Start()
    {

    }

    void Update()
    {




        // move character
        Vector2 leftInput = GetControllerInputLeft();
        Vector3 moveDirection = cameraTransform.forward * leftInput.y + cameraTransform.right * leftInput.x;
        moveDirection.y = 0f;
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);



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


}
