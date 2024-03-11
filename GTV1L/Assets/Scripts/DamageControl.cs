using UnityEngine;

/// <summary>
/// This is the overarching Script,
/// checking on damage done by areas or other game objects.
/// Takes into account possible armor being present on the game object
/// </summary>
[RequireComponent(typeof(Health), typeof(Armor))]
public class DamageControl : MonoBehaviour
{
    private Health healthComponent;
    private Armor armorComponent;
    
    /// <summary>
    /// initialize the variables to refer to the components on the game object.
    /// </summary>
    void Start()
    {
        healthComponent = GetComponent<Health>();
        armorComponent = GetComponent<Armor>();
    }
    
    /// <summary>
    /// Whenever this collides with another gameobject,
    /// - check if it's a DamageDealer
    /// - apply damage to health, taking armor into account
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            float proposedDamage = damageDealer.GetAmount();
            float currentArmor = armorComponent.GetArmorAmount();
            float actualDamage = Mathf.Clamp(proposedDamage - currentArmor, 0, proposedDamage);
            healthComponent.Decrease(actualDamage);
        }
    }
}
