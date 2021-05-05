using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellButton : MonoBehaviour, IPointerClickHandler
{
    public Spell Spell;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameMaster.GetInstance().SelectedSpell = Spell;
            Debug.Log($"{GameMaster.GetInstance().SelectedSpell.SpellName} Spell Selected.");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Spell.IsCharging = !Spell.IsCharging;
            Debug.Log($"{Spell.SpellName} Spell {(Spell.IsCharging ? "Now" : "Stopped")} Charging.");
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log($"{Spell.SpellName} Spell Middle Click Does Nothing.");
        }
    }
}
