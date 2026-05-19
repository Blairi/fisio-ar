using System.Collections.Generic;
using System.Text;

public class Exercise
{
    public string exerciseName;
    public int repetitions;
    public string animationTrigger;

    public Exercise(string name, int reps, string trigger)
    {
        exerciseName = name;
        repetitions = reps;
        animationTrigger = trigger;
    }

    public override string ToString()
    {
        return $"Exercise Name: {exerciseName}, " +
               $"Repetitions: {repetitions}, " +
               $"Animation Trigger: {animationTrigger}";
    }
}

public class Routine
{
    public string routineTitle;
    public string objective;
    public int durationMinutes;
    public List<Exercise> exerciseList;

    public Routine()
    {
        exerciseList = new List<Exercise>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Routine Title: {routineTitle}");
        sb.AppendLine($"Objective: {objective}");
        sb.AppendLine($"Duration: {durationMinutes} minutes");
        sb.AppendLine("Exercises:");

        if (exerciseList.Count == 0)
        {
            sb.AppendLine("  No exercises added.");
        }
        else
        {
            for (int i = 0; i < exerciseList.Count; i++)
            {
                sb.AppendLine($"  {i + 1}. {exerciseList[i]}");
            }
        }

        return sb.ToString();
    }
}