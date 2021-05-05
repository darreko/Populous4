using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public string SpellName;
    public int MaxCharges = 1;
    public int Charges = 0;
    public float ManaToCharge = 100;
    public float CurrentMana = 0;
    public bool IsCharging = false;

    public Button SpellButton;
    public Text SpellNameText;
    public Text SpellChargesText;
    public Text SpellPercentageText;

    private void Start()
    {
        SpellNameText.text = SpellName;
    }

    internal void AddMana(float mana)
    {
        CurrentMana += mana;

        if (Charges >= MaxCharges)
        {
            CurrentMana = 0;
        }
        else if (CurrentMana >= ManaToCharge)
        {
            Charges++;
            CurrentMana = 0;

            SetSpellChargesText();
        }

        SetSpellPercentageText();
    }

    private void SetSpellChargesText()
    {
        SpellChargesText.text = $"{Charges}/{MaxCharges}";
    }

    private void SetSpellPercentageText()
    {
        if (!IsCharging || (Charges >= MaxCharges))
        {
            SpellPercentageText.text = "";
        }
        else
        {
            SpellPercentageText.text = $"{(100 * CurrentMana / ManaToCharge).ToString("F0")}%";
        }
    }
}
