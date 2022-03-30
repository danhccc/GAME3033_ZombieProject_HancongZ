using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxHealthText;
    HealthComponent playerHealthComponent;

    private void OnHealthInitialized(HealthComponent healthComponent)
    {
        playerHealthComponent = healthComponent;
    }

    private void OnEnable()
    {
        PlayerEvents.OnHealthInitialize += OnHealthInitialized;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHealthInitialize -= OnHealthInitialized;

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealthComponent.CurrentHealth.ToString();
        maxHealthText.text = " / " + playerHealthComponent.MaxHealth.ToString();
    }
}
