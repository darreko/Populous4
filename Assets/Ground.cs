using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Debug.Log("Clicked the ground!");

        // TODO: use selected braves.
        var brave = GameMaster.GetInstance().Braves.FirstOrDefault();

        if (brave != null)
        {
            Debug.Log("Sending brave to location!");

            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var newPosition = hit.point;
                //transform.position = newPosition;
                Debug.Log($"Sending brave to position {newPosition}!");
                brave.SetTask(new MoveTask { Target = newPosition });
            }

        }
    }
}
