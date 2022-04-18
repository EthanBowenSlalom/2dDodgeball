using System;


public static class Actions
{
    // Player actions
    public static Action<Player> HealthPointsChange;
    public static Action<Player> EnergyPointsChange;
    public static Action<Player> HitCountChange;
    public static Action<Player> BallCountUpdate;

    // Power-Ups
    public static Action<PowerupType> PowerupPickedUp;
}
