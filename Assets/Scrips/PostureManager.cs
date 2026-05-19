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

        // Serializar la rutina
        Routine generatedRoutine = new Routine();

        if (cleanGoal == "sentado")
        {
            routineTitleText.text = "Postura al estar sentado";
            durationText.text = "5 min";
            objectiveText.text = "Objetivo: Activar core y estabilizar pelvis";
            exerciseListText.text = "• Inclinación pélvica\n• Estiramiento de isquiotibiales\n• Rotación torácica";

            // Llenar la rutina con ejercicios
            generatedRoutine.routineTitle = "Postura al estar sentado";
            generatedRoutine.durationMinutes = 5;
            generatedRoutine.objective = "Activar core y estabilizar pelvis";
            generatedRoutine.exerciseList.Add(new Exercise("Inclinación pélvica", 10, "Anim_PelvicTilt"));
            generatedRoutine.exerciseList.Add(new Exercise("Estiramiento isquiotibiales", 3, "Anim_HamstringStretch"));
            generatedRoutine.exerciseList.Add(new Exercise("Rotación torácica", 5, "Anim_ThoracicRotation"));
            
        }
        else if (cleanGoal == "celular")
        {
            routineTitleText.text = "Cuello por uso de celular";
            durationText.text = "4 min";
            objectiveText.text = "Objetivo: Aliviar tensión cervical superior";
            exerciseListText.text = "• Retracción cervical (Mentón atrás)\n• Estiramiento de trapecio\n• Movilidad de hombros";

            // Llenar la rutina con ejercicios
            generatedRoutine.routineTitle = "Cuello por uso de celular";
            generatedRoutine.durationMinutes = 4;
            generatedRoutine.objective = "Aliviar tensión cervical superior";
            generatedRoutine.exerciseList.Add(new Exercise("Retracción cervical (Mentón atrás)", 10, "Anim_ChinTuck"));
            generatedRoutine.exerciseList.Add(new Exercise("Estiramiento de trapecio", 3, "Anim_TrapStretch"));
            generatedRoutine.exerciseList.Add(new Exercise("Movilidad de hombros", 5, "Anim_ShoulderMobility"));
        }
        else if (cleanGoal == "encorvada")
        {
            routineTitleText.text = "Espalda encorvada";
            durationText.text = "7 min";
            objectiveText.text = "Objetivo: Fortalecer espalda alta y abrir pecho";
            exerciseListText.text = "• Postura de la cobra suave\n• Retracción escapular\n• Estiramiento pectoral en puerta";

            // Llenar la rutina con ejercicios
            generatedRoutine.routineTitle = "Espalda encorvada";
            generatedRoutine.durationMinutes = 7;
            generatedRoutine.objective = "Fortalecer espalda alta y abrir pecho";
            generatedRoutine.exerciseList.Add(new Exercise("Postura de la cobra suave", 10, "Anim_CobraPose"));
            generatedRoutine.exerciseList.Add(new Exercise("Retracción escapular", 3, "Anim_ScapularRetraction"));
            generatedRoutine.exerciseList.Add(new Exercise("Estiramiento pectoral en puerta", 5, "Anim_PecDoorwayStretch"));
        }
        else if (cleanGoal == "computadora")
        {
            routineTitleText.text = "Trabajo en computadora";
            durationText.text = "6 min";
            objectiveText.text = "Objetivo: Corrección postural integral";
            exerciseListText.text = "• Retracción cervical\n• Apertura de hombros\n• Corrección escapular";

            // Llenar la rutina con ejercicios
            generatedRoutine.routineTitle = "Trabajo en computadora";
            generatedRoutine.durationMinutes = 6;
            generatedRoutine.objective = "Corrección postural integral";
            generatedRoutine.exerciseList.Add(new Exercise("Retracción cervical", 10, "Anim_CervicalRetraction"));
            generatedRoutine.exerciseList.Add(new Exercise("Apertura de hombros", 3, "Anim_ShoulderOpening"));
            generatedRoutine.exerciseList.Add(new Exercise("Corrección escapular", 5, "Anim_ScapularCorrection"));
        }
        else
        {
            Debug.LogWarning("Objetivo no reconocido: '" + goal + "'");
        }

        SessionData.currentRoutine = generatedRoutine;
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