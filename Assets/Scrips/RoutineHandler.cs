using UnityEngine;

public class RoutineHandler : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject painLevelPanel;
    public GameObject routinePanel;

    // This function will be called when a routine button is clicked
    public void ShowPainLevelPanel()
    {
        // Hide the routines list panel
        painLevelPanel.SetActive(true);
        
        // Show the specific routine details panel
        routinePanel.SetActive(false);
    }

    // Function to go back to the routines list
    public void GoBackToRoutines()
    {
        routinePanel.SetActive(true);
        painLevelPanel.SetActive(false);
    }
}