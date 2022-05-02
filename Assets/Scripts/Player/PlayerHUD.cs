using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Bar oxygenBar;
    [SerializeField] private Bar healthBar;

    [SerializeField] private ItemUI itemUI;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthBar.SetValues(currentHealth, maxHealth);
    }

    public void UpdateOxygen(int currentOxygen, int maxOxygen)
    {
        oxygenBar.SetValues(currentOxygen, maxOxygen);
    }


    public void UpdateItemUI(Items newItem)
    {
        itemUI.UpdateInfo(newItem.icon);
    }
}
