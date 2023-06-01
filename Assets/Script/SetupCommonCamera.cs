using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCommonCamera : SetupCamera
{
    private void Start()
    {
        Camera = Instantiate(cameraPrefab).GetComponent<Camera>();
        var cameraMovement = Camera.gameObject.GetComponent<CameraMovement>();
        cameraMovement.TargetToFollow = transform;
    }
    private void OnEnable()
    {
        Camera?.gameObject?.SetActive(true);
    }
    private void OnDisable()
    {
        Camera?.gameObject?.SetActive(false);
    }
    private void OnDestroy()
    {
        Destroy(Camera.gameObject);
    }
}
