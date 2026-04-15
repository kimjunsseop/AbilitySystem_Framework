using UnityEngine;

public abstract class PresentationEffect : ScriptableObject
{
    public abstract void Play(AbilityContext context);
}