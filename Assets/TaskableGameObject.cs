using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class TaskableGameObject : MonoBehaviour
{
    public GameObject GO;
    private Queue<ITask> _Tasks = new Queue<ITask>();
    public ITask CurrentTask;
    public float Speed;

    public GameObject HoldingGO;

    // Update is called once per frame
    internal void Update()
    {
        PerformNextTask();
    }

    public void SetTask(ITask task)
    {
        _Tasks.Clear();
        CurrentTask = null;
        _Tasks.Enqueue(task);
    }

    public void QueueTask(ITask task)
    {
        _Tasks.Enqueue(task);
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
            if (_Tasks.Count > 0)
            {
                CurrentTask = _Tasks.Dequeue();
            }
        }

        // Perform the task.
        if (CurrentTask != null)
        {
            CurrentTask.Perform(this);
        }
    }

    public void PickUpObject(GameObject go)
    {
        if (HoldingGO != null)
        {
            go.transform.parent = gameObject.transform;
            go.transform.position = gameObject.transform.position + new Vector3(0, 1, 0);
        }
        else
        {
            Debug.Log(" Don't pick up. Already holding a log");
        }
    }
}
