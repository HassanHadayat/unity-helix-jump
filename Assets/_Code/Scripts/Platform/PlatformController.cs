using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform platformTrans;
    [SerializeField] private float rotateSpeed;
    Touch currTouch;

    void Update()
    {

        //if (!isReachedFinalDest)
        //{
        //    transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        //}

        // Horizontal Movement
        if (Input.touchCount > 0)
        {
            currTouch = Input.GetTouch(0);

            if (currTouch.phase == TouchPhase.Moved)
            {
                // Player Body Movement across Horizontal Axis

                float newY = currTouch.deltaPosition.x * rotateSpeed * Time.deltaTime;
                //Vector3 newRot = 
                Quaternion newRot = platformTrans.localRotation;
                newRot.y -= newY;
                platformTrans.localRotation = newRot;
                //platformTrans.localPosition = newPos;
            }

        }
    }
}
