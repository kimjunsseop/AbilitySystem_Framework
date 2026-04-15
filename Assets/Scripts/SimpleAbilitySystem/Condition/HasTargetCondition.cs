using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySystem/Conditions/HasTarget")]
public class HasTargetCondition : Condition
{
    public override bool Evaluate(AbilityContext context)
    {
        return context.targets != null && context.targets.Count > 0;
    }
}