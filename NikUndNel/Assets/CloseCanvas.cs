using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloseCanvas : MonoBehaviour
{
    public GameObject canvas; 

    public void Close()
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }
}
