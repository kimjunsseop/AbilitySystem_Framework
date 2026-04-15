using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySystem/Effects/SoundEffect")]
public class SoundEffect : Effect
{
    public AudioClip soundClip;

    public override void Apply(AbilityContext context)
    {
        if(soundClip != null)
        {
            
        }
    }
}