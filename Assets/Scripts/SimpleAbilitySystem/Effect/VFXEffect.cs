using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySystem/Effects/VFXEffect")]
public class VFXEffect : Effect
{
    public GameObject vfxPrefab;
    public Vector3 offset;
    public float destroyTime = 1.5f;

    public override void Apply(AbilityContext context)
    {
        if (context.targets == null || context.targets.Count == 0)
        {
            Debug.LogWarning("VFXEffect: targets 없음");
            return;
        }

        foreach (var target in context.targets)
        {
            if (target == null) continue;

            GameObject vfx = Instantiate(
                vfxPrefab,
                target.transform.position + offset,
                Quaternion.identity
            );

            Destroy(vfx, destroyTime);
        }
    }
}