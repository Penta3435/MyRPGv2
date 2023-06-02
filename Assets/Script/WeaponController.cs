using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected PlayerInput playerInput;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform hand;

    [Header("Default Weapon")]
    [SerializeField] protected GameObject weapon1;
    [SerializeField] protected GameObject meleeWeapon;
    public void Atack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            PlayAtackAnimation();
    }
    public virtual void EquipWeapon(GameObject weapon)
    {
        Weapon weaponComponent = weapon.GetComponent<Weapon>();
        if(weaponComponent.WeaponType == WeaponType.TankWeapon)
        {
            UnequipWeapon(WeaponContainer.Weapon1Container);
            weapon1 = Instantiate(weapon, hand);
            UseWeapon(WeaponContainer.Weapon1Container);
        }
        else if(weaponComponent.WeaponType == WeaponType.TankMelee)
        {
            UnequipWeapon(WeaponContainer.MeleeWeaponContainer);
            meleeWeapon = Instantiate(weapon, hand);
        }
    }
    public virtual void UnequipWeapon(WeaponContainer weaponContainer)
    {
        if(weaponContainer == WeaponContainer.Weapon1Container)
        {
            Destroy(weapon1);
            weapon1 = null;
            meleeWeapon.SetActive(true);
        }
        else
        {
            Destroy(meleeWeapon);
            meleeWeapon = null;
        }
    }
    public virtual void SwitchWeapon()
    {
        if (weapon1 == null) return;

        if (meleeWeapon.activeSelf == true)
        {
            UseWeapon(WeaponContainer.Weapon1Container);
        }
        else
        {
            UseWeapon(WeaponContainer.MeleeWeaponContainer);
        }
    }
    public virtual void SwitchToMelee()
    {
        UseWeapon(WeaponContainer.MeleeWeaponContainer);
    }
    protected virtual void UseWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.Weapon1Container && weapon1 == null)
        {
            meleeWeapon.SetActive(false);
            weapon1.SetActive(true);
        }
        else
        {
            weapon1.SetActive(false);
            meleeWeapon.SetActive(true);
        }
    }
    void PlayAtackAnimation()
    {
        animator.SetTrigger("Atack");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WeaponDrop") && playerInput.actions.FindActionMap("PlayerRunning").FindAction("EquipWeapon").WasPerformedThisFrame())
        {
            print("WEQUIP");
            EquipWeapon(other.GetComponent<WeaponDrop>().Weapon);
        }
    }
}
