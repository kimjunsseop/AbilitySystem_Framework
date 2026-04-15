using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "AbilitySystem/Ability")]
public class Ability : ScriptableObject
{
    public string abilityName;

    [Header("Cooldown")]
    public float cooldown;

    [Header("Targeting")]
    public TargetSelector targetSelector;

    [Header("Conditions")]
    public List<Condition> conditions;

    [Header("Logic Effects")]
    public List<Effect> effects;

    [Header("Presentation Effects")]
    public List<PresentationEffect> presentationEffects;

    [Header("Timing")]
    public float castTime;
}