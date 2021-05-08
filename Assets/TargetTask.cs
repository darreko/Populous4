using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// A task for a villager to do that focuses on a target.
/// </summary>
public abstract class TargetTask : ITask
{
    public GameObject TargetGO;

    public abstract bool IsComplete(TaskableGameObject gameObject);

    public abstract void Perform(TaskableGameObject gameObject);
}
