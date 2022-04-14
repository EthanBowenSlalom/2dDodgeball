using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPointsUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;

    public void OnEnable()
    {
        Actions.HealthPointsChange += OnHealthPointsChange;
    }

    public void OnDisable()
    {
        Actions.HealthPointsChange -= OnHealthPointsChange;
    }

    void Start()
    {
        tmpText.text = "Health: ";
    }

    private void OnHealthPointsChange(Player player)
    {
        tmpText.text = "Health: " + player.healthPoints;
    }

}
