using UnityEngine;
using TMPro;

public class ARUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject scanPromptPanel;
    public GameObject routineInfoPanel;

    [Header("Routine Text Elements")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI objectiveText;

    public void ShowScanPrompt()
    {
        scanPromptPanel.SetActive(true);
        routineInfoPanel.SetActive(false);
    }

    public void ShowRoutineInfo(string title, int duration, string objective)
    {
        scanPromptPanel.SetActive(false);
        routineInfoPanel.SetActive(true);

        titleText.text = title;
        durationText.text = "Tiempo: " + duration + " min";
        objectiveText.text = "Objetivo: " + objective;
    }

    public void HideAllPanels()
    {
        scanPromptPanel.SetActive(false);
        routineInfoPanel.SetActive(false);
    }
}