using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollow : MonoBehaviour
{
    [SerializeField] private Transform ballTrans;



    private void Update()
    {
        if (ballTrans != null) {
        

            if(ballTrans.position.y < transform.position.y)
            {
                transform.position = ballTrans.position;
            }
        }
    }
}
