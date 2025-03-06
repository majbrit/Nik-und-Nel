using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnType : MonoBehaviour
{
    // Referenzen auf die Turn-Provider
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;

    private void Start()
    {
        // Sicherheitsprüfung: Sicherstellen, dass die Referenzen im Inspector gesetzt sind
        if (snapTurn == null || continuousTurn == null)
        {
            Debug.LogError("Snap Turn oder Continuous Turn Provider ist nicht zugewiesen!");
            return;
        }

        // Standardmäßig Snap Turn aktivieren
        SetTypeFromIndex(0); // Standard zu Continuous Turn (oder ändere zu 1 für Snap Turn)
    }

    /// <summary>
    /// Aktiviert entweder Continuous Turn oder Snap Turn basierend auf dem Index.
    /// </summary>
    /// <param name="index">0: Continuous Turn, 1: Snap Turn</param>
    public void SetTypeFromIndex(int index)
    {
        if (snapTurn == null || continuousTurn == null)
        {
            Debug.LogError("Snap Turn oder Continuous Turn ist nicht verfügbar!");
            return;
        }

        if (index == 0)
        {
            Debug.Log("Wechsle zu Continuous Turn");
            
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }
        else if (index == 1)
        {
            Debug.Log("Wechsle zu Snap Turn");
            
            continuousTurn.enabled = false;
            snapTurn.enabled = true;
        }
        else
        {
            Debug.LogError("Ungültiger Index: " + index);
        }
    }
}
