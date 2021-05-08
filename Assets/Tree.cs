using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour
{
    public GameObject TreeGO;
    public GameObject WoodPrefab;

    private const int MaxWoodCount = 4;
    public float WoodCount = 4;
    public float WoodGrowthPerMinute = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Grow();
    }

    public Wood Chop()
    {
        WoodCount--;
        var woodChopped = Instantiate(WoodPrefab, transform.position + new Vector3(0, 5), Quaternion.identity);

        if (WoodCount < 1)
        {
            // Chopped the entire tree
            WoodCount = -2;
        }

        return woodChopped.GetComponent<Wood>();
    }

    private void Grow()
    {
        if (WoodCount > MaxWoodCount)
        {
            WoodCount = MaxWoodCount;
            return;
        }
        else if (WoodCount == MaxWoodCount)
        {
            return;
        }

        WoodCount += (WoodGrowthPerMinute / 60) * Time.deltaTime;

        TreeGO.transform.localScale = Vector3.one * Mathf.Max(WoodCount, 0) / MaxWoodCount;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }

    // TODO: change this to add task to selected brave(s).
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (WoodCount < 1)
        {
            // Not enough wood to chop.
            return;
        }

        Debug.Log("Clicked the tree!");

        var brave = GameMaster.GetInstance().Braves.FirstOrDefault();

        if (brave != null)
        {
            Debug.Log("Sending brave to chop the tree!");

            brave.SetTask(new TreeTask { TargetGO = gameObject });
        }
    }
}
