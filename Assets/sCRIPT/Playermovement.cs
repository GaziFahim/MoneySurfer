using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float playerSpeed;
    public float swerveValue;
    public float clampDistanceX;
    public Transform playerModelRoot;
   
    private Touch touch;
    private Vector3 myTouchPosition;
    void Start()
    {
        
    }

    private void PlayerMovement()
    {
        Vector3 runForward = transform.forward * Time.deltaTime * playerSpeed;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                myTouchPosition = touch.deltaPosition;

                if (myTouchPosition.x > 0)
                {
                    playerModelRoot.localPosition += new Vector3(swerveValue, 0, 0);
                }
                else
                {
                    playerModelRoot.localPosition += new Vector3(-swerveValue, 0, 0);
                }

                Vector3 playerPosition = playerModelRoot.localPosition;
                playerPosition.x = Mathf.Clamp(playerPosition.x, -clampDistanceX, clampDistanceX);
                playerModelRoot.localPosition = playerPosition;
            }
        }



       transform.Translate(runForward);
    }

    public void playrmovementPc()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * 10;

        transform.Translate(h, 0, 5 * Time.deltaTime);
        Vector3 playerPosition = playerModelRoot.localPosition;
        playerPosition.x = Mathf.Clamp(playerPosition.x, -clampDistanceX, clampDistanceX);
        playerModelRoot.localPosition = playerPosition;
    }
    void Update()
    {

       // playrmovementPc();

         PlayerMovement();



    }


}
