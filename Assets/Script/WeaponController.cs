using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected PlayerInput playerInput;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform hand;
    [SerializeField] protected WeaponType[] canEquipWeaponType;

    [Header("Default Weapon")]
    [SerializeField] protected GameObject[] weapons;
    [SerializeField] protected GameObject meleeWeapon;

    Stack<GameObject> weaponsStack;

    protected void Awake()
    {
        weaponsStack = new Stack<GameObject>(weapons);
    }



    public virtual void Atack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            animator.SetTrigger("Atack");
    }
    protected virtual void EquipWeapon(GameObject weapon)
    {
        bool canEquip = false;
        foreach(var weaponType in canEquipWeaponType)
        {
            if (weapon.GetComponent<Weapon>().WeaponType == weaponType) 
            { 
                canEquip = true;
                break;
            }
        }
        if (!canEquip) return;


        if(weaponsStack.Count != weapons.Length)
        {
            for (int weaponInt = 0; weaponInt < weapons.Length; weaponInt++)
            {
                if (weapons[weaponInt] == null)
                {
                    weapons[weaponInt] = weapon;
                    weaponsStack.Push(weapon);
                    UseWeapon(weaponInt);
                    return;
                }
            }
        }
        else
        {
            for (int weaponInt = 0; weaponInt < weapons.Length; weaponInt++)
            {
                if (weapons[weaponInt].activeSelf == true)
                {
                    UnequipWeapon(weaponInt);
                    weapons[weaponInt] = weapon;
                    weaponsStack.Push(weapon);
                    UseWeapon(weaponInt);
                    return;
                }
                else
                {
                    UnequipWeapon(weaponInt);
                    weapons[weaponInt] = weapon;
                    weaponsStack.Push(weapon);
                    UseWeapon(weaponInt);
                    return;
                }
            }
        }
    //    Weapon weaponComponent = weapon.GetComponent<Weapon>();
    //    if(weaponComponent.WeaponType == WeaponType.TankWeapon)
    //    {
    //        UnequipWeapon(WeaponContainer.Weapon1Container);
    //        weapon1 = Instantiate(weapon, hand);
    //        UseWeapon(WeaponContainer.Weapon1Container);
    //    }
    //    else if(weaponComponent.WeaponType == WeaponType.TankMelee)
    //    {
    //        UnequipWeapon(WeaponContainer.MeleeWeaponContainer);
    //        meleeWeapon = Instantiate(weapon, hand);
    //    }
    }
    public virtual void UnequipWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.Weapon1Container)
        {
            if (weapons[0].activeSelf == true) meleeWeapon.SetActive(true);
            Destroy(weapons[0]);
            weapons[0] = null;
            weaponsStack = new Stack<GameObject>(weapons);
        }
        else
        {
            Destroy(meleeWeapon);
            meleeWeapon = null;
            weaponsStack = new Stack<GameObject>(weapons);
        }
    }
    public virtual void UnequipWeapon(int weaponInt)
    {
        if (weapons[weaponInt].activeSelf == true) meleeWeapon.SetActive(true); 
        Destroy(weapons[weaponInt]);
        weapons[weaponInt] = null;
        weaponsStack = new Stack<GameObject>(weapons);
    }
    //public virtual void SwitchWeapon()
    //{
    //    if (weapon1 == null) return;

    //    if (meleeWeapon.activeSelf == true)
    //    {
    //        UseWeapon(WeaponContainer.Weapon1Container);
    //    }
    //    else
    //    {
    //        UseWeapon(WeaponContainer.MeleeWeaponContainer);
    //    }
    //}
    public virtual void SwitchToMelee()
    {
        UseWeapon(WeaponContainer.MeleeWeaponContainer);
    }
    protected virtual void UseWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.Weapon1Container && weapons[0] == null)
        {
            meleeWeapon.SetActive(false);
            weapons[0].SetActive(true);
            animator.runtimeAnimatorController = weapons[0].GetComponent<Weapon>().AnimatorController;
        }
        else
        {
            meleeWeapon.SetActive(true);
            weapons[0].SetActive(false);
            animator.runtimeAnimatorController = weapons[1].GetComponent<Weapon>().AnimatorController;
        }
    }
    protected virtual void UseWeapon(int weaponInt)
    {
        foreach(var weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[weaponInt].SetActive(true);
        animator.runtimeAnimatorController = weapons[weaponInt].GetComponent<Weapon>().AnimatorController;
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("WeaponDrop") && playerInput.actions.FindActionMap("PlayerRunning").FindAction("EquipWeapon").WasPerformedThisFrame())
    //    {
    //        print("equip");
    //        EquipWeapon(other.GetComponent<WeaponDrop>().Weapon);
    //    }
    //}
}
