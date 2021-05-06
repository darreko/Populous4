using UnityEngine;

/// <summary>
/// A place for a villager to go.
/// </summary>
public class MoveTask : ITask
{
    public Vector3 Target;
    private bool _IsComplete = false;

    public bool IsComplete(TaskableGameObject gameObject)
    {
        return _IsComplete;
    }

    public void Perform(TaskableGameObject gameObject)
    {
        var dir = Target - gameObject.transform.position;
        var distanceThisFrame = gameObject.Speed * Time.deltaTime;

        if (dir.magnitude < distanceThisFrame)
        {
            _IsComplete = true;
            return;
        }

        gameObject.transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        gameObject.transform.LookAt(Target);
    }
}
