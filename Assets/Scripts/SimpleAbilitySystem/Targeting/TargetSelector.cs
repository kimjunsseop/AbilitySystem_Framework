using UnityEngine;
using System.Collections.Generic;

public abstract class TargetSelector : ScriptableObject
{
    public abstract List<GameObject> Select(AbilityContext context);
}