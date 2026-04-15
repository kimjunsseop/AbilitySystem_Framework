using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySystem/Effects/DamageEffect")]
public class DamageEffect : Effect
{
    public int damage = 10;

    public override void Apply(AbilityContext context)
    {
        if (context.targets == null || context.targets.Count == 0)
        {
            Debug.LogWarning("DamageEffect: targets 없음");
            return;
        }

        foreach (var target in context.targets)
        {
            if (target == null) continue;

            Debug.Log($"{target.name} 에게 {damage} 데미지 줬다");

            // 실제 데미지 처리 (예시)
            // var hp = target.GetComponent<IDamageable>();
            // if (hp != null)
            // {
            //     hp.TakeDamage(damage);
            // }
        }
    }
}