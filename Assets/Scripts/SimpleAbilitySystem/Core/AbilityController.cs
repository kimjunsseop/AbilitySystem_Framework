using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AbilityRunner))]
public class AbilityController : MonoBehaviour
{
    public List<Ability> abilities;

    private AbilityRunner runner;
    private CooldownHandler cooldownHandler;

    void Awake()
    {
        runner = GetComponent<AbilityRunner>();
        cooldownHandler = new CooldownHandler();
    }

    public bool TryUseAbility(Ability ability)
    {
        if (!abilities.Contains(ability))
        {
            Debug.LogWarning("Ability 없음");
            return false;
        }

        if (!cooldownHandler.IsReady(ability))
        {
            Debug.Log("쿨타임 중");
            return false;
        }

        var context = new AbilityContext
        {
            caster = gameObject
        };

        // Target 선정
        context.targets = ability.targetSelector.Select(context);

        // Condition 체크
        foreach (var condition in ability.conditions)
        {
            if (!condition.Evaluate(context))
            {
                Debug.Log("조건 불충족");
                return false;
            }
        }

        runner.Run(ability, context);
        cooldownHandler.Trigger(ability);

        AbilityEvents.OnAbilityUsed?.Invoke(ability);

        return true;
    }
}