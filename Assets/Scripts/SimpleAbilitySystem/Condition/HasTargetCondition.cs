using UnityEngine;

// 해당 내용은 예시를 위해 만들어진 Condition 입니다. 타겟유무를 기반으로 작동하는 예시 Condition입니다.
[CreateAssetMenu(menuName = "AbilitySystem/Conditions/HasTarget")]
public class HasTargetCondition : Condition
{
    public override bool Evaluate(AbilityContext context)
    {
        return context.targets != null && context.targets.Count > 0;
    }
}


