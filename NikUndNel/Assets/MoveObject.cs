using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveAndSnapObject : MonoBehaviour
{
    public float gridSize = 0.2f; // Größe der Zellen im Grid

    private void SnapToGrid()
    {
        Debug.Log("SnapToGrid wurde aufgerufen!");
        // Runden der Position auf das nächste Grid
        float snapX = Mathf.Round(transform.position.x / gridSize) * gridSize;
        float snapY = Mathf.Round(transform.position.y / gridSize) * gridSize;
        float snapZ = Mathf.Round(transform.position.z / gridSize) * gridSize;

        // Setze die Position des Objekts auf das Grid
        transform.position = new Vector3(snapX, snapY, snapZ);
        Quaternion currentRotation = transform.rotation;
        Vector3 eulerRotation = currentRotation.eulerAngles;

        // Rotation auf bestimmte Winkel beschränken
        float snappedX = Mathf.Round(eulerRotation.x / 90) * 90;
        float snappedY = Mathf.Round(eulerRotation.y / 90) * 90;
        float snappedZ = Mathf.Round(eulerRotation.z / 90) * 90;

        transform.rotation = Quaternion.Euler(snappedX, snappedY, snappedZ);


        // Ausgabe für Debugging
        Debug.Log($"Snapping to: {transform.position}");
        Debug.Log($"Current rotation: {currentRotation.eulerAngles}");
    }

    public MoveAndSnapObject snapManager;

    /*
    private void Start()
    {
        if (snapManager != null && targetObject != null)
        {
            snapManager.SnapObjectToGrid(targetObject);
        }
        else
        {
            Debug.LogWarning("SnapManager oder Zielobjekt fehlt!");
        }
    }*/

    // Diese Methode wird aufgerufen, wenn das Objekt losgelassen wird
    public void OnRelease()
    {
      //  SnapToGrid(); // Raste das Objekt auf das Grid
    }
}
