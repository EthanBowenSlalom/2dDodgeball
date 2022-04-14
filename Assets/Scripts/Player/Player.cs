using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int healthPoints { get; set; } = 100;
    public int energyPoints { get; set; } = 150;
    public int hitCount { get; set; } = 0;
    public int dodgeBallCount { get; set; } = 0;


    public void AddHealthPoints(int healthPointsDelta)
    {
        healthPoints += healthPointsDelta;

        Actions.HealthPointsChange?.Invoke(this);
    }

    public void SubstractHealthPoints(int healthPointsDelta)
    {
        healthPoints -= healthPointsDelta;

        Actions.HealthPointsChange?.Invoke(this);
    }

    public void AddEnergyPoints(int energyPointsDelta)
    {
        energyPoints += energyPointsDelta;
        Actions.EnergyPointsChange?.Invoke(this);
    }

    public void SubtractEnergyPoints(int energyPointsDelta)
    {
        energyPoints -= energyPointsDelta;
        Actions.EnergyPointsChange?.Invoke(this);
    }

    public void AddHitCount()
    {
        hitCount++;
        Actions.HitCountChange?.Invoke(this);
    }

    public void BallThrown()
    {
        dodgeBallCount--;
        Actions.BallCountUpdate?.Invoke(this);
    }

    public void BallPickedup()
    {
        dodgeBallCount++;
        Actions.BallCountUpdate?.Invoke(this);
    }


    public bool CanThrowDodgeball()
    {
        return dodgeBallCount > 0;
    }
}
