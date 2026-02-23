using UnityEngine;

public class HealthPotion : PickUp
{
    [SerializeField] private int healAmount = 30;
    [SerializeField] private GameObject healEffect;

    protected override void OnTriggerEnter(Collider other)
    {
        Destructible destructible = other.GetComponent<Destructible>();

        if (destructible != null)
        {
            // ¬ычисл€ем, сколько здоровь€ нужно восстановить
            int maxHP = destructible.GetMaxHitPoints();
            int currentHP = destructible.GetHitPoints();
            int healNeeded = Mathf.Min(healAmount, maxHP - currentHP);

            if (healNeeded > 0)
            {
                // ѕримен€ем отрицательный урон = лечение
                destructible.ApplyDamage(-healNeeded);

                if (healEffect != null)
                    Instantiate(healEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}