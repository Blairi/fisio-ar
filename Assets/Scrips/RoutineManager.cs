using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoutineManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject routinesListPanel;
    public GameObject painEvaluationPanel;
    public GameObject painLocationPanel; // Panel intermedio para el cuello
    public GameObject recommendedRoutinePanel;

    [Header("Inputs & State")]
    public Slider painSlider;
    private int storedPainLevel = 0;
    private string currentJoint = ""; // Guardará "Rodilla" o "Cuello"

    [Header("Recommended Routine UI")]
    public TextMeshProUGUI routineTitleText;
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI exerciseListText;
    public GameObject disclaimerTextObject;

    // 1. Función para definir qué parte del cuerpo se evaluará
    public void SetTargetJoint(string jointName)
    {
        currentJoint = jointName;
        
        // Reiniciamos el slider al valor mínimo por defecto
        painSlider.value = 1;
        
        routinesListPanel.SetActive(false);
        
        // Mostramos el panel de evaluación de dolor
        painEvaluationPanel.SetActive(true);
    }

    // 2. Función que se llama al confirmar el nivel de dolor en el Slider
    public void ConfirmPainLevel()
    {
        storedPainLevel = (int)painSlider.value;
        painEvaluationPanel.SetActive(false);

        // Bifurcación del flujo dependiendo de la articulación
        if (currentJoint == "Rodilla")
        {
            GenerateKneeRoutine();
        }
        else if (currentJoint == "Cuello")
        {
            painLocationPanel.SetActive(true);
        }
    }

    // 3. Función exclusiva para los botones del panel de ubicación del cuello
    public void SelectPainLocation(string location)
    {
        painLocationPanel.SetActive(false);
        GenerateNeckRoutine(location);
    }

    // --- LÓGICA DE GENERACIÓN DE RUTINAS ---

    private void GenerateKneeRoutine()
    {
        recommendedRoutinePanel.SetActive(true);
        disclaimerTextObject.SetActive(false);

        // Serializar la rutina
        Routine generatedRoutine = new Routine();

        if (storedPainLevel >= 1 && storedPainLevel <= 3)
        {
            routineTitleText.text = "Rodilla - Intensidad Baja";
            durationText.text = "5 min";
            objectiveText.text = "Objetivo: Aliviar tensión";
            exerciseListText.text = "• Flexión suave\n• Extensión controlada\n• Descanso guiado";


            generatedRoutine.routineTitle = "Rodilla - Intensidad Baja";
            generatedRoutine.durationMinutes = 5;
            generatedRoutine.objective = "Aliviar tensión";
            generatedRoutine.exerciseList.Add(new Exercise("Flexión suave", 10, "Anim_KneeFlexion"));
            generatedRoutine.exerciseList.Add(new Exercise("Extensión controlada", 3, "Anim_KneeExtension"));
            generatedRoutine.exerciseList.Add(new Exercise("Descanso guiado", 5, "Anim_GuidedRest"));
        }
        else if (storedPainLevel >= 4 && storedPainLevel <= 6)
        {
            routineTitleText.text = "Rodilla - Intensidad Media";
            durationText.text = "10 min";
            objectiveText.text = "Objetivo: Movilidad y fortalecimiento ligero";
            exerciseListText.text = "• Sentadillas isométricas\n• Elevación de pierna recta\n• Estiramiento de pantorrilla";

            generatedRoutine.routineTitle = "Rodilla - Intensidad Media";
            generatedRoutine.durationMinutes = 10;
            generatedRoutine.objective = "Movilidad y fortalecimiento ligero";
            generatedRoutine.exerciseList.Add(new Exercise("Sentadillas isométricas", 10, "Anim_IsometricSquats"));
            generatedRoutine.exerciseList.Add(new Exercise("Elevación de pierna recta", 3, "Anim_LegLift"));
            generatedRoutine.exerciseList.Add(new Exercise("Estiramiento de pantorrilla", 5, "Anim_CalfStretch"));
        }
        else if (storedPainLevel >= 7 && storedPainLevel <= 10)
        {
            routineTitleText.text = "Rodilla - Intensidad Muy Baja (Recuperación)";
            durationText.text = "3 min";
            objectiveText.text = "Objetivo: Movilidad pasiva sin carga";
            exerciseListText.text = "• Movimientos de tobillo\n• Deslizamiento de talón asistido";

            generatedRoutine.routineTitle = "Rodilla - Intensidad Muy Baja (Recuperación)";
            generatedRoutine.durationMinutes = 3;
            generatedRoutine.objective = "Movilidad pasiva sin carga";
            generatedRoutine.exerciseList.Add(new Exercise("Movimientos de tobillo", 10, "Anim_AnkleMovements"));
            generatedRoutine.exerciseList.Add(new Exercise("Deslizamiento de talón asistido", 5, "Anim_HeelSlide"));

            disclaimerTextObject.SetActive(true); 
        }

        SessionData.currentRoutine = generatedRoutine;
    }

    private void GenerateNeckRoutine(string location)
    {
        recommendedRoutinePanel.SetActive(true);
        disclaimerTextObject.SetActive(false);

        string baseTitle = "Cuello (" + location + ")";

        Routine generatedRoutine = new Routine();

        if (storedPainLevel >= 1 && storedPainLevel <= 3)
        {
            routineTitleText.text = baseTitle + " - Intensidad Baja";
            durationText.text = "5 min";
            objectiveText.text = "Objetivo: Liberar tensión";
            exerciseListText.text = "• Inclinación lateral suave\n• Rotación controlada\n• Descanso guiado";

            generatedRoutine.routineTitle = baseTitle + " - Intensidad Baja";
            generatedRoutine.durationMinutes = 5;
            generatedRoutine.objective = "Liberar tensión";
            generatedRoutine.exerciseList.Add(new Exercise("Inclinación lateral suave", 10, "Anim_LateralNeckTilt"));
            generatedRoutine.exerciseList.Add(new Exercise("Rotación controlada", 3, "Anim_NeckRotation"));
            generatedRoutine.exerciseList.Add(new Exercise("Descanso guiado", 5, "Anim  GuidedRest"));
        }
        else if (storedPainLevel >= 4 && storedPainLevel <= 6)
        {
            routineTitleText.text = baseTitle + " - Intensidad Media";
            durationText.text = "8 min";
            objectiveText.text = "Objetivo: Movilidad y estiramiento ligero";
            exerciseListText.text = "• Flexión y extensión\n• Estiramiento con apoyo\n• Ejercicios isométricos";

            generatedRoutine.routineTitle = baseTitle + " - Intensidad Media";
            generatedRoutine.durationMinutes = 8;
            generatedRoutine.objective = "Movilidad y estiramiento ligero";
            generatedRoutine.exerciseList.Add(new Exercise("Flexión y extensión", 10, "Anim_NeckFlexionExtension"));
            generatedRoutine.exerciseList.Add(new Exercise("Estiramiento con apoyo", 3, "Anim_SupportedNeckStretch"));
            generatedRoutine.exerciseList.Add(new Exercise("Ejercicios isométricos", 5, "Anim_IsometricNeckExercises"));
        }
        else if (storedPainLevel >= 7 && storedPainLevel <= 10)
        {
            routineTitleText.text = baseTitle + " - Recuperación";
            durationText.text = "3 min";
            objectiveText.text = "Objetivo: Movilidad pasiva muy suave";
            exerciseListText.text = "• Respiración diafragmática\n• Movimientos milimétricos";
            generatedRoutine.routineTitle = baseTitle + " - Recuperación";
            generatedRoutine.durationMinutes = 3;
            generatedRoutine.objective = "Movilidad pasiva muy suave";
            generatedRoutine.exerciseList.Add(new Exercise("Respiración diafragmática", 5, "Anim_DiaphragmaticBreathing"));
            generatedRoutine.exerciseList.Add(new Exercise("Movimientos milimétricos", 3, "Anim_MillimeterMovements"));
            disclaimerTextObject.SetActive(true); 
        }

        SessionData.currentRoutine = generatedRoutine;
    }

    // --- NAVEGACIÓN GENERAL ---

    public void StartARRoutine()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void GoBackToPainEvaluation()
    {
        recommendedRoutinePanel.SetActive(false);
        painLocationPanel.SetActive(false);
        painEvaluationPanel.SetActive(true);
    }
}