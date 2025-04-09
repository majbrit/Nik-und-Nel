using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharFollower : MonoBehaviour
{
    public GameObject character;
    public Vector3 offsetCharCam = new Vector3(0, 2, -4);
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        /*Vector3 desiredPosition = character.transform.position + character.transform.TransformDirection(offsetCharCam);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.LookAt(character.transform.position + Vector3.up * 1.5f);*/

    }
}
