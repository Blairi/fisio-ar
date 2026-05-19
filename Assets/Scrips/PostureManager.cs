using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PostureManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject routinesListPanel;
    public GameObject postureQuestionPanel;
    public GameObject postureRoutinePanel;

    [Header("Routine UI Elements")]
    public TextMeshProUGUI routineTitleText;
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI exerciseListText;

    // 1. Inicia el flujo desde el menú principal
    public void StartPostureFlow()
    {
        routinesListPanel.SetActive(false);
        postureQuestionPanel.SetActive(true);
    }

    // 2. Se ejecuta al presionar uno de los 4 botones de objetivo
    public void SelectPostureGoal(string goal)
    {
        postureQuestionPanel.SetActive(false);
        postureRoutinePanel.SetActive(true);

        string cleanGoal = goal.Trim().ToLower();

        if (cleanGoal == "sentado")
        {
            routineTitleText.text = "Postura al estar sentado";
            durationText.text = "5 min";
            objectiveText.text = "Objetivo: Activar core y estabilizar pelvis";
            exerciseListText.text = "• Inclinación pélvica\n• Estiramiento de isquiotibiales\n• Rotación torácica";
        }
        else if (cleanGoal == "celular")
        {
            routineTitleText.text = "Cuello por uso de celular";
            durationText.text = "4 min";
            objectiveText.text = "Objetivo: Aliviar tensión cervical superior";
            exerciseListText.text = "• Retracción cervical (Mentón atrás)\n• Estiramiento de trapecio\n• Movilidad de hombros";
        }
        else if (cleanGoal == "encorvada")
        {
            routineTitleText.text = "Espalda encorvada";
            durationText.text = "7 min";
            objectiveText.text = "Objetivo: Fortalecer espalda alta y abrir pecho";
            exerciseListText.text = "• Postura de la cobra suave\n• Retracción escapular\n• Estiramiento pectoral en puerta";
        }
        else if (cleanGoal == "computadora")
        {
            routineTitleText.text = "Trabajo en computadora";
            durationText.text = "6 min";
            objectiveText.text = "Objetivo: Corrección postural integral";
            exerciseListText.text = "• Retracción cervical\n• Apertura de hombros\n• Corrección escapular";
        }
        else
        {
            Debug.LogWarning("Objetivo no reconocido: '" + goal + "'");
        }
    }

    // 3. Navegación
    public void StartARRoutine()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoBackToQuestions()
    {
        postureRoutinePanel.SetActive(false);
        postureQuestionPanel.SetActive(true);
    }

    public void GoBackToMenu()
    {
        postureQuestionPanel.SetActive(false);
        routinesListPanel.SetActive(true);
    }
}