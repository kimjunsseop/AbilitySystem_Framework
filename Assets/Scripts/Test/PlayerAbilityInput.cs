using UnityEngine;

public class PlayerAbilityInput : MonoBehaviour
{
    public AbilityController controller;
    public Ability fireball;
    public Ability shootAbility;
    public float Speed = 5f;
    float h;
    float v;

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(h, 0, v) * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            controller.TryUseAbility(fireball);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            controller.TryUseAbility(shootAbility);
        }
    }
}