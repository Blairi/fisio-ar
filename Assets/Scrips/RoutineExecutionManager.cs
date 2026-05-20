using System.Collections;
using UnityEngine;

public class RoutineExecutionManager : MonoBehaviour
{
    [Header("Dependencies")]
    public ARUIManager uiManager;
    public Animator avatarAnimator;

    private Routine currentRoutine;
    private int currentExerciseIndex = 0;
    
    private float exerciseTimer = 0f;
    private bool isRunning = false;
    private bool isPaused = false;

    public void StartRoutineExecution()
    {
        currentRoutine = SessionData.currentRoutine;
        
        if (currentRoutine == null || currentRoutine.exerciseList.Count == 0)
        {
            Debug.LogError("No hay rutina cargada en memoria.");
            return;
        }

        currentExerciseIndex = 0;
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        isRunning = false;
        
        uiManager.ShowCountdown("3");
        yield return new WaitForSeconds(1f);
        
        uiManager.ShowCountdown("2");
        yield return new WaitForSeconds(1f);
        
        uiManager.ShowCountdown("1");
        yield return new WaitForSeconds(1f);
        
        uiManager.ShowCountdown("INICIAR");
        yield return new WaitForSeconds(1f);

        LoadExercise(currentExerciseIndex);
    }

    private void LoadExercise(int index)
    {
        Exercise ex = currentRoutine.exerciseList[index];
        uiManager.ShowActiveExercise(ex.exerciseName);
        
        exerciseTimer = ex.repetitions * 5f; 
        
        isPaused = false;
        uiManager.TogglePauseText(isPaused);
        
        if (avatarAnimator != null && !string.IsNullOrEmpty(ex.animationTrigger))
        {
            avatarAnimator.SetTrigger(ex.animationTrigger);
        }

        isRunning = true;
    }

    void Update()
    {
        if (isRunning && !isPaused)
        {
            exerciseTimer -= Time.deltaTime;
            
            int seconds = Mathf.CeilToInt(exerciseTimer);
            if (seconds < 0) seconds = 0; 
            uiManager.UpdateTimerDisplay(seconds.ToString() + " s");

            // Cuando el tiempo llega a cero
            if (exerciseTimer <= 0)
            {
                isRunning = false; // Detenemos la lógica

                // Comprobamos si hay un siguiente ejercicio en la lista
                if (currentExerciseIndex < currentRoutine.exerciseList.Count - 1)
                {
                    // Si lo hay, mostramos la pantalla intermedia y le pasamos el nombre
                    Exercise nextEx = currentRoutine.exerciseList[currentExerciseIndex + 1];
                    uiManager.ShowNextExercisePrompt(nextEx.exerciseName);

                    if (avatarAnimator != null)
                    {
                        // Ponemos al avatar en posición de descanso mientras el paciente decide continuar
                        avatarAnimator.SetTrigger("Anim_Idle"); 
                    }
                }
                else
                {
                    // Si era el último ejercicio, terminamos la rutina
                    FinishRoutine();
                }
            }
        }
    }

    // Esta es la nueva función que conectaremos al botón "Continuar"
    public void ContinueToNextExercise()
    {
        currentExerciseIndex++;
        
        // Opcional: podrías volver a llamar a StartCoroutine(CountdownRoutine()) aquí 
        // si quieres que haya otro 3, 2, 1 antes del nuevo ejercicio.
        // Por ahora, lo cargamos directamente para mayor fluidez.
        LoadExercise(currentExerciseIndex);
    }

    public void TogglePause()
    {
        if (!isRunning) return;

        isPaused = !isPaused;
        uiManager.TogglePauseText(isPaused);
        
        if (avatarAnimator != null)
        {
            avatarAnimator.speed = isPaused ? 0f : 1f; 
        }
    }

    public void RestartRoutine()
    {
        StopAllCoroutines();
        
        if (avatarAnimator != null)
        {
            avatarAnimator.speed = 1f; 
            avatarAnimator.Rebind(); 
        }

        currentExerciseIndex = 0;
        StartCoroutine(CountdownRoutine());
    }

    private void FinishRoutine()
    {
        isRunning = false;
        uiManager.ShowFinishedPanel();
        
        if (avatarAnimator != null)
        {
            avatarAnimator.SetTrigger("Anim_Idle"); 
        }
    }
}