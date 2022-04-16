using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public int HealthPoints { get; set; } = 100;
        public int EnergyPoints { get; set; } = 150;
        public int HitCount { get; set; } = 0;
        public int DodgeBallCount { get; set; } = 0;


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
    }
}
