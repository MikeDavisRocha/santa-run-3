using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler_Setup : MonoBehaviour {
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Transform followTransform;
	
    private Vector3 GetCameraPosition() {
		return followTransform.position + new Vector3(0, 35f);        
    }
}
