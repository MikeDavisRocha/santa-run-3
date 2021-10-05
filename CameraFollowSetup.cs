using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSetup : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    private Transform followTransform;
    [SerializeField] private float zoom;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        followTransform = FindObjectOfType<PlayerInput>().transform;
    }

    private void Start()
    {
        if (followTransform == null)
        {
            Debug.LogError("followTransform is null! Intended?");
            cameraFollow.Setup(() => Vector3.zero, () => zoom, true, true);
        }
        else
        {
            cameraFollow.Setup(() => followTransform.position, () => zoom, true, true);
        }
    }

}