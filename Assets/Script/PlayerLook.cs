using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public Camera cam; 
    public float xRotation = 0f;
    public float xSensitivity = 30;
    public float ySensitivity = 30;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //calculate camera roation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity; 
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //Apply this to our camera transform. 
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotate the player body left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * xSensitivity));
    }
}
