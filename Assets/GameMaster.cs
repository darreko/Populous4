using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject BraveGO; 
    public List<Brave> Braves;
    public Displayable<int> Population;
    public Displayable<float> ManaPerSecond;

    // TODO: Populate list of spells from what is inside the spells panel instead of having to also populate this list manually.
    public GameObject SpellsPanelGO;
    public List<Spell> Spells;
    public Spell SelectedSpell;

    private static GameMaster _Instance;

    public static GameMaster GetInstance()
    {
        return _Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_Instance != null)
        {
            throw new Exception("Multiple Game Masters");
        }

        _Instance = this;

        Spells = SpellsPanelGO.GetComponentsInChildren<Spell>().ToList();

        foreach (var spell in Spells)
        {
            Debug.Log($"Found {spell.SpellName} spell!");
        }
    }

    private double _SecondsSincePopulationIncrease = 0;

    // Update is called once per frame
    void Update()
    {
        //IncreasePopulationOverTime();
        GenerateMana();
    }

    private float _TimeSinceManaCalculation = 0;

    private void GenerateMana()
    {
        _TimeSinceManaCalculation += Time.deltaTime;

        if (_TimeSinceManaCalculation > 1)
        {
            _TimeSinceManaCalculation = 0;
            ManaPerSecond.Value = Braves.Sum(b => b.GetManaGeneratedPerSecond());
        }

        var manaToDistribute = ManaPerSecond.Value * Time.deltaTime;

        var chargingSpells = Spells.Where(s => s.IsCharging && s.Charges < s.MaxCharges);
        var chargingSpellsCount = chargingSpells.Count();
        var manaEach = manaToDistribute / chargingSpellsCount;

        foreach (var spell in chargingSpells)
        {
            spell.AddMana(manaEach);
        }
    }

    private void IncreasePopulationOverTime()
    {
        _SecondsSincePopulationIncrease += Time.deltaTime;

        if (_SecondsSincePopulationIncrease >= 1)
        {
            var newBravePosition = new Vector3(UnityEngine.Random.Range(0, 20) / 10f, 1, UnityEngine.Random.Range(0, 20) / 10f);

            var newBraveGo = Instantiate(BraveGO, newBravePosition, Quaternion.identity);
            Braves.Add(newBraveGo.GetComponent<Brave>());

            Population.Value = Braves.Count;
            _SecondsSincePopulationIncrease = 0;
        }
    }
}
