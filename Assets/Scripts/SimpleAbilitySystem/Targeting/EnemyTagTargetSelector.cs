using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "AbilitySystem/Targeting/All Enemies By Tag")]
public class EnemyTagTargetSelector : TargetSelector
{
    public string targetTag = "Enemy";

    public override List<GameObject> Select(AbilityContext context)
    {
        List<GameObject> targets = new List<GameObject>();

        GameObject[] found = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (var obj in found)
        {
            // 자기 자신 제외 (필요하면)
            if (obj == context.caster)
                continue;

            targets.Add(obj);
        }

        return targets;
    }
}