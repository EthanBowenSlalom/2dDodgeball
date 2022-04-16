using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using TMPro;

public class HitCountUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;

    public void OnEnable()
    {
        Actions.HitCountChange += OnHitCountChange;
    }

    public void OnDisable()
    {
        Actions.HitCountChange -= OnHitCountChange;
    }


    void Start()
    {
        tmpText.text = "Hit: ";
    }

    private void OnHitCountChange(PlayerStats playerStats)
    {
        tmpText.text = "Hit: " + playerStats.HitCount;
    }
    
}
