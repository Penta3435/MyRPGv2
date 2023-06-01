using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(SetupCamera))]
public class CharacterRotation : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] SetupCamera camera;
    [SerializeField] Transform hand;
    void LateUpdate()
    {
        CharacterRotationMethod();
    }

    public void CharacterRotationMethod()
    {
        Vector2 mousePosition = playerInput.actions.FindActionMap("PlayerRunning").FindAction("MousePosition").ReadValue<Vector2>();
        Ray ray = camera.Camera.ScreenPointToRay(mousePosition);
        Plane weaponHightPlane = new Plane(Vector3.up, hand.position);
        if (weaponHightPlane.Raycast(ray, out float rayDistance))
        {
            Vector3 mouseWorldPosition = new Vector3(ray.GetPoint(rayDistance).x, transform.position.y, ray.GetPoint(rayDistance).z);
            transform.LookAt(mouseWorldPosition);
        }

    }
}
