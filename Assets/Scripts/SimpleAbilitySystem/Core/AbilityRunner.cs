using UnityEngine;
using System.Collections;

public class AbilityRunner : MonoBehaviour
{
    public void Run(Ability ability, AbilityContext context)
    {
        StartCoroutine(ExecuteRoutine(ability, context));
    }

    private IEnumerator ExecuteRoutine(Ability ability, AbilityContext context)
    {
        // Cast Time
        if (ability.castTime > 0)
            yield return new WaitForSeconds(ability.castTime);

        // Logic
        foreach (var effect in ability.effects)
        {
            effect.Apply(context);
        }

        // Presentation
        foreach (var p in ability.presentationEffects)
        {
            p.Play(context);
        }
    }
}