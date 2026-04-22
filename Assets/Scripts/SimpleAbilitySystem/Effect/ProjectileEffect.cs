using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySystem/Effects/ProjectileEffect")]
public class ProjectileEffect : Effect
{
    public GameObject projectilePrefab;
    public float speed = 10f;

    public override void Apply(AbilityContext context)
    {
        foreach (var target in context.targets)
        {
            Vector3 dir = (target.transform.position - context.caster.transform.position).normalized;

            GameObject proj = Instantiate(
                projectilePrefab,
                context.caster.transform.position,
                Quaternion.LookRotation(dir)
            );

            Rigidbody rb = proj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = dir * speed;
            }
        }
    }
}