using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Text currentHealthText;
    [SerializeField] private Text maxHealthText;
    [SerializeField] private ItemUI itemUI;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        currentHealthText.text = currentHealth.ToString();
        maxHealthText.text = maxHealth.ToString();
    }

    public void UpdateItemUI(Items newItem)
    {
        itemUI.UpdateInfo(newItem.icon);
    }
}
