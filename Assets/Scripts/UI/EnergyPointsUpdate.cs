using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using TMPro;

public class EnergyPointsUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;


    public void OnEnable()
    {
        Actions.EnergyPointsChange += OnEnergyPointsChange;
    }

    public void OnDisable()
    {
        Actions.EnergyPointsChange -= OnEnergyPointsChange;
    }

    void Start()
    {
        tmpText.text = "Energy: ";
    }

    private void OnEnergyPointsChange(PlayerStats playerStats)
    {
        tmpText.text = "Energy: " + playerStats.EnergyPoints;
    }

}
