using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using TMPro;

public class BallCountUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;


    public void OnEnable()
    {
        Actions.BallCountUpdate += OnBallCountUpdate;
    }

    public void OnDisable()
    {
        Actions.BallCountUpdate -= OnBallCountUpdate;
    }

    void Start()
    {
        tmpText.text = "Dodge Balls: ";
    }

    private void OnBallCountUpdate(PlayerStats playerStats)
    {
        tmpText.text = "Dodge Balls: " + playerStats.DodgeBallCount;
    }

}
