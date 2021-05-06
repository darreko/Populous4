using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// A task for a villager to do that focuses on a target.
/// </summary>
public class TargetTask : ITask
{
    public GameObject TargetGO;
    private bool _IsComplete = false;

    public bool IsComplete(TaskableGameObject gameObject)
    {
        return _IsComplete;
    }

    public void Perform(TaskableGameObject gameObject)
    {
        var treeTarget = TargetGO.GetComponent<Tree>();
        
        if (treeTarget != null)
        {
            // TODO: first move to the tree using a move task, not copying its code.
            var dir = TargetGO.transform.position - gameObject.transform.position;
            var distanceThisFrame = gameObject.Speed * Time.deltaTime;

            if (dir.magnitude < 1.5)
            {
                // Chop at the tree
                // TODO: give the wood to the brave.
                var woodChopped = treeTarget.Chop();
                _IsComplete = true;
                Debug.Log("Brave chopped the tree!");
            }
            else
            {
                Debug.Log($"Brave is {dir.magnitude} units from the tree.");
            }

            gameObject.transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            gameObject.transform.LookAt(TargetGO.transform.position);
        }
    }
}
