using System.Collections;
using Powerups;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public int HealthPoints { get; set; } = 100;
        public int EnergyPoints { get; set; } = 150;
        public int HitCount { get; set; } = 0;
        public int DodgeBallCount { get; set; } = 0;

        public int powerupSpeedBoost = 1;
        public bool isDoubleShot = false;

        private void Awake()
        {
            Actions.PowerupPickedUp += PowerupPickedUp;
        }

        public void AddHealthPoints(int healthPointsDelta)
        {
            HealthPoints += healthPointsDelta;

            Actions.HealthPointsChange?.Invoke(this);
        }

        public void SubstractHealthPoints(int healthPointsDelta)
        {
            HealthPoints -= healthPointsDelta;

            Actions.HealthPointsChange?.Invoke(this);
        }

        public void AddEnergyPoints(int energyPointsDelta)
        {
            EnergyPoints += energyPointsDelta;
            Actions.EnergyPointsChange?.Invoke(this);
        }

        public void SubtractEnergyPoints(int energyPointsDelta)
        {
            EnergyPoints -= energyPointsDelta;
            Actions.EnergyPointsChange?.Invoke(this);
        }

        public void AddHitCount()
        {
            HitCount++;
            Actions.HitCountChange?.Invoke(this);
        }

        public void BallThrown()
        {
            DodgeBallCount--;
            Actions.BallCountUpdate?.Invoke(this);
        }

        public void BallPickedup()
        {
            DodgeBallCount++;
            Actions.BallCountUpdate?.Invoke(this);
        }


        public bool CanThrowDodgeball()
        {
            return DodgeBallCount > 0;
        }

        public void PowerupPickedUp(PowerupType powerupType)
        {
            switch (powerupType)
            {
                case PowerupType.DoubleShot:
                    StartCoroutine(DoubleShotPowerUp());
                    break;
                case PowerupType.DoubleSpeed:
                    StartCoroutine(DoubleSpeedPowerUp());
                    break;
                default: break;
            }
        }

        private IEnumerator DoubleSpeedPowerUp()
        {
            float duration = 5f; // 3 seconds you can change this to
            powerupSpeedBoost *= 2;

            yield return new WaitForSeconds(duration);

            powerupSpeedBoost /= 2;
        }

        private IEnumerator DoubleShotPowerUp()
        {
            float duration = 5f; // 3 seconds you can change this to

            isDoubleShot = true;
            yield return new WaitForSeconds(duration);
            isDoubleShot = false;
        }
    }
}
