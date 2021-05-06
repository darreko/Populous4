using UnityEngine;

public class Brave : TaskableGameObject
{
    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        Tasks.Enqueue(new MoveTask { Target = new Vector3(10, 0.5f, 10) });
    }

    // TODO: rework this, it was just a test.
    public float GetManaGeneratedPerSecond()
    {
        var rb = GetComponent<Rigidbody>();
        var v3Velocity = rb.velocity;

        if (v3Velocity.magnitude > 0.1)
        {
            return 1;
        }
        else
        {
            return 0.5f;
        }
    }
}
