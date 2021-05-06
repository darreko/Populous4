using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class TaskableGameObject : MonoBehaviour
{
    public GameObject GO;
    public Queue<ITask> Tasks = new Queue<ITask>();
    public ITask CurrentTask;
    public float Speed;

    // Update is called once per frame
    internal void Update()
    {
        PerformNextTask();
    }

    private void PerformNextTask()
    {
        // Check for task completed.
        if (CurrentTask?.IsComplete(this) == true)
        {
            CurrentTask = null;
        }

        // Try to get a new task if needed.
        if (CurrentTask == null)
        {
            if (Tasks.Count > 0)
            {
                CurrentTask = Tasks.Dequeue();
            }
        }

        // Perform the task.
        if (CurrentTask != null)
        {
            CurrentTask.Perform(this);
        }
    }
}
