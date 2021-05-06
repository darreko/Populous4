using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// A task for a villager to do.
/// </summary>
public interface ITask
{
    public void Perform(TaskableGameObject gameObject);

    public bool IsComplete(TaskableGameObject gameObject);
}
