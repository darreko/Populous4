using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brave : MonoBehaviour
{
    public int Health = 100;
    public GameObject GO;

    //public float ManaGeneratedPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

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
