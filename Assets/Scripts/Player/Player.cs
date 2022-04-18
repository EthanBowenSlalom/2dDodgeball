using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int healthPoints { get; set; } = 100;
    public int energyPoints { get; set; } = 150;
    public int hitCount { get; set; } = 0;
    public int dodgeBallCount { get; set; } = 0;

    public int powerupSpeedBoost = 1;
    public bool isDoubleShot = false;

    private void Awake()
    {
        Actions.PowerupPickedUp += PowerupPickedUp;
    }

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


    public void PowerupPickedUp(PowerupType powerupType)
    {
        switch (powerupType)
        {
            case PowerupType.DoubleShot:
                DoubleShotPowerUp();
                break;
            case PowerupType.DoubleSpeed:
                DoubleSpeedPowerUp();
                break;
            default: break;
        }
    }

    private IEnumerator DoubleSpeedPowerUp()
    {
        float duration = 5f; // 3 seconds you can change this to
                             //to whatever you want
        float totalTime = 0;

        powerupSpeedBoost *= 2;
        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }

        powerupSpeedBoost /= 2;
    }

    private IEnumerator DoubleShotPowerUp()
    {
        float duration = 5f; // 3 seconds you can change this to
                             //to whatever you want
        float totalTime = 0;

        isDoubleShot = true;
        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }

        isDoubleShot = false;
    }

}
