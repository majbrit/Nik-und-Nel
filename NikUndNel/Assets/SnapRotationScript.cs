using UnityEngine;

public class SnapRotation : MonoBehaviour
{
    private void OnDisable()
    {
        // Hole die aktuelle Rotation
        Vector3 rotation = transform.rotation.eulerAngles;

        // Runde die Rotationswerte auf die nächsten 30°
        rotation.x = Mathf.Round(rotation.x / 30) * 30;
        rotation.y = Mathf.Round(rotation.y / 30) * 30;
        rotation.z = Mathf.Round(rotation.z / 30) * 30;

        // Setze die gerundete Rotation
        transform.rotation = Quaternion.Euler(rotation);
    }
}

