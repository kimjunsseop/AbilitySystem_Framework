using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "AbilitySystem/TargetSelector/NearestEnemy")]
public class NearestEnemySelector : TargetSelector
{
    public float range = 10f;

    public override List<GameObject> Select(AbilityContext context)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject closest = null;
        float minDist = float.MaxValue;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(context.caster.transform.position, e.transform.position);
            if (dist < range && dist < minDist)
            {
                minDist = dist;
                closest = e;
            }
        }

        return closest != null ? new List<GameObject> { closest } : new List<GameObject>();
    }
}