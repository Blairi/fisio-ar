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

        if (storedPainLevel >= 1 && storedPainLevel <= 3)
        {
            routineTitleText.text = "Rodilla - Intensidad Baja";
            durationText.text = "5 min";
            objectiveText.text = "Objetivo: Aliviar tensión";
            exerciseListText.text = "• Flexión suave\n• Extensión controlada\n• Descanso guiado";
        }
        else if (storedPainLevel >= 4 && storedPainLevel <= 6)
        {
            routineTitleText.text = "Rodilla - Intensidad Media";
            durationText.text = "10 min";
            objectiveText.text = "Objetivo: Movilidad y fortalecimiento ligero";
            exerciseListText.text = "• Sentadillas isométricas\n• Elevación de pierna recta\n• Estiramiento de pantorrilla";
        }
        else if (storedPainLevel >= 7 && storedPainLevel <= 10)
        {
            routineTitleText.text = "Rodilla - Intensidad Muy Baja (Recuperación)";
            durationText.text = "3 min";
            objectiveText.text = "Objetivo: Movilidad pasiva sin carga";
            exerciseListText.text = "• Movimientos de tobillo\n• Deslizamiento de talón asistido";
            
            disclaimerTextObject.SetActive(true); 
        }
    }

    private void GenerateNeckRoutine(string location)
    {
        recommendedRoutinePanel.SetActive(true);
        disclaimerTextObject.SetActive(false);

        string baseTitle = "Cuello (" + location + ")";

        if (storedPainLevel >= 1 && storedPainLevel <= 3)
        {
            routineTitleText.text = baseTitle + " - Intensidad Baja";
            durationText.text = "5 min";
            objectiveText.text = "Objetivo: Liberar tensión";
            exerciseListText.text = "• Inclinación lateral suave\n• Rotación controlada\n• Descanso guiado";
        }
        else if (storedPainLevel >= 4 && storedPainLevel <= 6)
        {
            routineTitleText.text = baseTitle + " - Intensidad Media";
            durationText.text = "8 min";
            objectiveText.text = "Objetivo: Movilidad y estiramiento ligero";
            exerciseListText.text = "• Flexión y extensión\n• Estiramiento con apoyo\n• Ejercicios isométricos";
        }
        else if (storedPainLevel >= 7 && storedPainLevel <= 10)
        {
            routineTitleText.text = baseTitle + " - Recuperación";
            durationText.text = "3 min";
            objectiveText.text = "Objetivo: Movilidad pasiva muy suave";
            exerciseListText.text = "• Respiración diafragmática\n• Movimientos milimétricos";
            
            disclaimerTextObject.SetActive(true); 
        }
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