using System;
using Powerups;

namespace Player
{
    public static class Actions
    {
        // Player actions
        public static Action<PlayerStats> HealthPointsChange;
        public static Action<PlayerStats> EnergyPointsChange;
        public static Action<PlayerStats> HitCountChange;
        public static Action<PlayerStats> BallCountUpdate;

        // Power-Ups
        public static Action<PowerupType> PowerupPickedUp;
    }
}
