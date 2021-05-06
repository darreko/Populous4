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
    public Sprite SpellImageSprite;

    public Button SpellButton;
    public Image SpellImage;
    public Text SpellNameText;
    public Text SpellChargesText;
    public Text SpellPercentageText;

    private void Start()
    {
        SpellNameText.text = SpellName;
        SpellImage.sprite = SpellImageSprite;
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

            UpdateSpellChargesText();
        }

        UpdateSpellPercentageText();
    }

    public void UpdateSpellChargesText()
    {
        SpellChargesText.text = $"{Charges}/{MaxCharges}";
    }

    public void UpdateSpellPercentageText()
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
