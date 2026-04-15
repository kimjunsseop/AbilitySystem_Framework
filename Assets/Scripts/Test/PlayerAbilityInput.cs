using UnityEngine;

public class PlayerAbilityInput : MonoBehaviour
{
    public AbilityController controller;
    public Ability fireball;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            controller.TryUseAbility(fireball);
        }
    }
}