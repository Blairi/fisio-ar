using UnityEngine;

public class ARController : MonoBehaviour
{
    void Start()
    {
        if (SessionData.currentRoutine != null)
        {
            Debug.Log("Rutina cargada: " + SessionData.currentRoutine);
        }
    }
}