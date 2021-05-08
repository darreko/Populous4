using UnityEngine;

/// <summary>
/// A task for a villager to do that focuses on a tree.
/// </summary>
public class TreeTask : TargetTask
{
    private bool _IsComplete = false;

    public override bool IsComplete(TaskableGameObject gameObject)
    {
        return _IsComplete;
    }

    public override void Perform(TaskableGameObject gameObject)
    {
        // Don't allow a character to hold multiple objects.
        if (gameObject.HoldingGO != null)
        {
            Debug.Log(" Don't chop. Already holding a log");
            _IsComplete = true;
            return;
        }

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
                gameObject.PickUpObject(woodChopped.gameObject);
                _IsComplete = true;
            }

            gameObject.transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            gameObject.transform.LookAt(TargetGO.transform.position);
        }
    }
}
