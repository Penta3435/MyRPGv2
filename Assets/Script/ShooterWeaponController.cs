using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//public class ShooterWeaponController : WeaponController
//{
//    [Header("Default Weapon")]
//    [SerializeField] GameObject weapon2;

//    protected override void EquipWeapon(GameObject weapon)
//    {
//        Weapon weaponComponent = weapon.GetComponent<Weapon>();
//        if (weaponComponent.WeaponType == WeaponType.ShooterRange)
//        {
//            if(weapon1 == null)
//            {
//                weapon1 = Instantiate(weapon, hand);
//            }
//            else if (weapon2 == null)
//            {
//                weapon2 = Instantiate(weapon, hand);
//            }
//            else if (weapon2.activeSelf == true)
//            {
//                UnequipWeapon(WeaponContainer.Weapon2Container);
//                weapon2 = Instantiate(weapon, hand);
//            }
//            else
//            {
//                UnequipWeapon(WeaponContainer.Weapon1Container);
//                weapon1 = Instantiate(weapon, hand);
//            }
//        }
//        else if (weaponComponent.WeaponType == WeaponType.ShooterMelee)
//        {
//            UnequipWeapon(WeaponContainer.MeleeWeaponContainer);
//            meleeWeapon = Instantiate(weapon, hand);
//        }
//    }
//    public override void UnequipWeapon(WeaponContainer weaponContainer)
//    {
//        switch (weaponContainer)
//        {
//            case WeaponContainer.Weapon1Container:
//                if (weapon1 == null) return;
//                if (weapon1.activeSelf == true) UseWeapon(WeaponContainer.MeleeWeaponContainer);
//                Destroy(weapon1);
//                weapon1 = null;
//                break;

//            case WeaponContainer.Weapon2Container:
//                if (weapon2 == null) return;
//                if (weapon2.activeSelf == true) UseWeapon(WeaponContainer.MeleeWeaponContainer);
//                Destroy(weapon2);
//                weapon2 = null;
//                break;
//            default:
//                if (meleeWeapon == null) return;
//                Destroy(meleeWeapon);
//                meleeWeapon = null;
//                break;
//        }
//    }
//    public override void SwitchWeapon()
//    {
//        if(weapon1 != null && weapon2 != null)
//        {
//            if(weapon1.activeSelf == true)
//            {
//                UseWeapon(WeaponContainer.Weapon2Container);
//            }
//            else 
//            {
//                UseWeapon(WeaponContainer.Weapon1Container);
//            }
//        }
//        else if(weapon1 != null ||  weapon2 != null)
//        {
//            if (meleeWeapon.activeSelf == true)
//            {
//                if (weapon1 != null) UseWeapon(WeaponContainer.Weapon1Container);
//                else UseWeapon(WeaponContainer.Weapon2Container);
//            }
//            else
//                UseWeapon(WeaponContainer.MeleeWeaponContainer);
//        }
//    }
//    protected override void UseWeapon(WeaponContainer weaponContainer)
//    {
//        if (weaponContainer == WeaponContainer.Weapon1Container && weapon1 == null)
//        {
//            weapon1.SetActive(true);
//            weapon2.SetActive(false);
//            meleeWeapon.SetActive(false);
//            animator.runtimeAnimatorController = weapon1.GetComponent<Weapon>().AnimatorController;
//        }
//        else if(weaponContainer == WeaponContainer.Weapon2Container && weapon2 == null)
//        {
//            weapon1.SetActive(false);
//            weapon2.SetActive(true);
//            meleeWeapon.SetActive(false);
//            animator.runtimeAnimatorController = weapon2.GetComponent<Weapon>().AnimatorController;
//        }
//        else
//        {
//            weapon1.SetActive(false);
//            weapon2.SetActive(false);
//            meleeWeapon.SetActive(true);
//            animator.runtimeAnimatorController = meleeWeapon.GetComponent<Weapon>().AnimatorController;
//        }
//    }
//}
