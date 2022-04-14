using System.Collections;
using System.Collections.Generic;
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

    private void OnBallCountUpdate(Player player)
    {
        tmpText.text = "Dodge Balls: " + player.dodgeBallCount;
    }

}
