using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSessionManager : MonoBehaviour
{
    [Header("Managers")]
    public ARUIManager uiManager;
    public RoutineExecutionManager executionManager;

    void Start()
    {
        uiManager.ShowScanPrompt();
    }

    // --- EVENTOS DE VUFORIA ---

    public void OnTargetFound()
    {
        if (SessionData.currentRoutine != null)
        {
            Routine current = SessionData.currentRoutine;
            
            // Le pasamos los datos puros al UI Manager para que él los dibuje
            uiManager.ShowRoutineInfo(current.routineTitle, current.durationMinutes, current.objective);
            Debug.Log("Target detectado. Rutina cargada exitosamente.");
        }
        else
        {
            uiManager.ShowRoutineInfo("Modo de Prueba (Sin Datos)", 0, "No definido");
            Debug.LogWarning("No se encontraron datos en SessionData.");
        }
    }

    public void OnTargetLost()
    {
        uiManager.ShowScanPrompt();
        Debug.Log("Target perdido.");
    }

    // --- ACCIONES DE LOS BOTONES ---

    public void StartExercise()
    {
        executionManager.StartRoutineExecution();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartingScreen"); 
    }
}