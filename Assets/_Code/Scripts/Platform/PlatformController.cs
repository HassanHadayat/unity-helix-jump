using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform platformTrans;
    [SerializeField] private float rotateSpeed;
    Touch currTouch;
    private float screenWidth;

    private void Start()
    {
        screenWidth = Screen.currentResolution.width;
    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            currTouch = Input.GetTouch(0);

            if (currTouch.phase == TouchPhase.Moved)
            {
                // Delta Angle
                float deltaAngle = currTouch.deltaPosition.x * (360 / screenWidth); // deltaX * anglePerResolution

                platformTrans.Rotate(Vector3.up, -deltaAngle);
            }

        }

    }
}
