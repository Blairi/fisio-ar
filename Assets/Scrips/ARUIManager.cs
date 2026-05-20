using UnityEngine;
using TMPro;

public class ARUIManager : MonoBehaviour
{
    [Header("Pre-Exercise Panels")]
    public GameObject scanPromptPanel;
    public GameObject routineInfoPanel;

    [Header("Execution Panels")]
    public GameObject countdownPanel;
    public GameObject activeExercisePanel;
    public GameObject nextExercisePromptPanel;
    public GameObject finishedPanel;

    [Header("Pre-Exercise Texts")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI objectiveText;

    [Header("Execution Texts")]
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI currentExerciseTitleText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI pauseButtonText; 
    public TextMeshProUGUI nextExerciseNameText;

    public void ShowScanPrompt()
    {
        HideAll();
        scanPromptPanel.SetActive(true);
    }

    public void ShowRoutineInfo(string title, int duration, string objective)
    {
        HideAll();
        routineInfoPanel.SetActive(true);
        titleText.text = title;
        durationText.text = "Tiempo: " + duration + " min";
        objectiveText.text = "Objetivo: " + objective;
    }

    public void ShowCountdown(string count)
    {
        HideAll();
        countdownPanel.SetActive(true);
        countdownText.text = count;
    }

    public void ShowActiveExercise(string exerciseTitle)
    {
        HideAll();
        activeExercisePanel.SetActive(true);
        currentExerciseTitleText.text = exerciseTitle;
    }

    // Nueva función para mostrar la pantalla intermedia
    public void ShowNextExercisePrompt(string nextExerciseName)
    {
        HideAll();
        nextExercisePromptPanel.SetActive(true);
        nextExerciseNameText.text = nextExerciseName;
    }

    public void UpdateTimerDisplay(string timeString)
    {
        timerText.text = timeString;
    }

    public void TogglePauseText(bool isPaused)
    {
        pauseButtonText.text = isPaused ? "Reanudar" : "Pausa";
    }

    public void ShowFinishedPanel()
    {
        HideAll();
        finishedPanel.SetActive(true);
    }

    private void HideAll()
    {
        scanPromptPanel.SetActive(false);
        routineInfoPanel.SetActive(false);
        countdownPanel.SetActive(false);
        activeExercisePanel.SetActive(false);
        nextExercisePromptPanel.SetActive(false);
        finishedPanel.SetActive(false);
    }
}