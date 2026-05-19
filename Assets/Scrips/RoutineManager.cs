using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoutineManager : MonoBehaviour
{
    [Header("Input UI")]
    public Slider painSlider;
    public GameObject painEvaluationPanel; 

    [Header("Recommended Routine UI")]
    public GameObject recommendedRoutinePanel;
    public TextMeshProUGUI routineTitleText;
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI exerciseListText;
    public GameObject disclaimerTextObject;

    // Esta función se llamará cuando el usuario confirme su nivel de dolor
    public void GenerateRoutine()
    {
        int painLevel = (int)painSlider.value;

        // Ocultar pantalla de dolor, mostrar pantalla de rutina
        painEvaluationPanel.SetActive(false);
        recommendedRoutinePanel.SetActive(true);

        // Apagar el disclaimer por defecto, solo se enciende si el dolor es fuerte
        disclaimerTextObject.SetActive(false);

        // Lógica de asignación según el dolor
        if (painLevel >= 1 && painLevel <= 3)
        {
            routineTitleText.text = "Rodilla - Intensidad Baja";
            durationText.text = "5 min";
            objectiveText.text = "Objetivo: Aliviar tensión";
            exerciseListText.text = "• Flexión suave\n• Extensión controlada\n• Descanso guiado";
        }
        else if (painLevel >= 4 && painLevel <= 6)
        {
            routineTitleText.text = "Rodilla - Intensidad Media";
            durationText.text = "10 min";
            objectiveText.text = "Objetivo: Movilidad y fortalecimiento ligero";
            exerciseListText.text = "• Sentadillas isométricas\n• Elevación de pierna recta\n• Estiramiento de pantorrilla";
        }
        else if (painLevel >= 7 && painLevel <= 10)
        {
            routineTitleText.text = "Rodilla - Intensidad Muy Baja (Recuperación)";
            durationText.text = "3 min";
            objectiveText.text = "Objetivo: Movilidad pasiva sin carga";
            exerciseListText.text = "• Movimientos de tobillo\n• Deslizamiento de talón asistido";
            
            // Encender el mensaje de advertencia médica para dolor fuerte
            disclaimerTextObject.SetActive(true); 
        }
    }

    // Esta función se conectará al botón [Iniciar en RA]
    public void StartARRoutine()
    {
        // Reemplaza "EscenaAR" con el nombre real de AR
        SceneManager.LoadScene("MainScene"); 
    }

    public void GoBackToPainEvaluation()
    {
        recommendedRoutinePanel.SetActive(false);
        painEvaluationPanel.SetActive(true);
    }
}