using System;

public static class Actions
{
    // Player actions
    public static Action<Player> HealthPointsChange;
    public static Action<Player> EnergyPointsChange;
    public static Action<Player> HitCountChange;
}
