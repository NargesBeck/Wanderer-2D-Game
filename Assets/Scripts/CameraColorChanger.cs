using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    public bool toRed, toWhite;

    private Camera camera;
    private Camera Camera
    {
        get
        {
            if (camera == null)
                camera = GetComponent<Camera>();
            return camera;
        }

    }

    private float speedToRed = 0.2f;
    private float speedToWhite = 0.08f;

    private void Awake()
    {
        Player.Instance.OnBeingDamaged += TurnToRed;
    }

    void Update()
    {
        if (toRed)
        {
            Camera.backgroundColor = new Color(1, Camera.backgroundColor.g - speedToRed, Camera.backgroundColor.b - speedToRed);
            StopTurningRedIfItsTime();
        }
        else if (toWhite)
        {
            Camera.backgroundColor = new Color(1, Camera.backgroundColor.g + speedToWhite, Camera.backgroundColor.b + speedToWhite);
            StopTurningWhiteIfItsTime();
        }
    }
    
    private void TurnToRed()
    {
        toRed = !(toWhite = false);
    }

    private void StopTurningRedIfItsTime()
    {
        if (Camera.backgroundColor.g <= 0.7)
        {
            toRed = !(toWhite = true);
        }
    }

    private void StopTurningWhiteIfItsTime()
    {
        if (Camera.backgroundColor.g >= 1)
        {
            toWhite = false;
        }
    }
}