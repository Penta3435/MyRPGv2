using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCamera : MonoBehaviour
{
    [SerializeField] protected GameObject cameraPrefab;
    public Camera Camera { get; protected set; }
}
