using System.Collections.Generic;
using UnityEngine;

public class CooldownHandler
{
    class CooldownData
    {
        public float endTime;
    }

    private Dictionary<Ability, CooldownData> cooldowns = new();

    public bool IsReady(Ability ability)
    {
        if (!cooldowns.ContainsKey(ability))
            return true;

        return Time.time >= cooldowns[ability].endTime;
    }

    public void Trigger(Ability ability)
    {
        if (!cooldowns.ContainsKey(ability))
            cooldowns[ability] = new CooldownData();

        cooldowns[ability].endTime = Time.time + ability.cooldown;
    }
}