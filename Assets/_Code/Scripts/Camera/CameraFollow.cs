using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public CinemachineVirtualCamera virtualCamera;
    public float heightThreshold = 2.0f;
    public float heightSmoothTime = 0.5f;

    private float currentHeightVelocity = 0.0f;

    private void LateUpdate()
    {
        //if (playerTransform != null)
        //{
        //    Vector3 playerPosition = playerTransform.position;
        //    Vector3 cameraPosition = virtualCamera.transform.position;

        //    Debug.Log((cameraPosition.y - playerPosition.y));
        //    // Check if the player is above the height threshold
        //    if (cameraPosition.y - playerPosition.y > heightThreshold)
        //    {
        //        // Smoothly adjust the camera's height
        //        float targetHeight = playerPosition.y - heightThreshold;
        //        cameraPosition.y = Mathf.SmoothDamp(cameraPosition.y, targetHeight, ref currentHeightVelocity, heightSmoothTime);
        //        virtualCamera.transform.position = cameraPosition;
        //    }
        //}
    }





    //public Transform playerTransform;
    //public float heightThreshold = 2.0f;
    //public float heightSmoothTime = 0.5f;

    //private float currentHeightVelocity = 0.0f;

    //private void LateUpdate()
    //{
    //    if (playerTransform != null)
    //    {
    //        //transform.LookAt(playerTransform.position);

    //        Vector3 playerPosition = playerTransform.position;
    //        Vector3 cameraPosition = transform.position;

    //        Debug.Log((cameraPosition.y - playerPosition.y));
    //        // Check if the player is above the height threshold
    //        if (cameraPosition.y - playerPosition.y > heightThreshold)
    //        {
    //            // Smoothly adjust the camera's height
    //            float targetHeight = playerPosition.y - heightThreshold;
    //            cameraPosition.y = Mathf.SmoothDamp(cameraPosition.y, targetHeight, ref currentHeightVelocity, heightSmoothTime);
    //            transform.position = cameraPosition;
    //        }
    //    }
    //}
}
