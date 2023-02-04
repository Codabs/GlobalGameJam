using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;
using DG.Tweening;

public class TestingTouchAsset : MonoBehaviour
{
    
    [SerializeField] private new Transform camera;
    [SerializeField] private float movementPower = 5;
    [SerializeField] private PressGesture pressComponent;
    [SerializeField] private ReleaseGesture releaseComponent;
    private float lastPositionTap = 0;
    private void OnEnable()
    {
        pressComponent.Pressed += pressHandler;
        releaseComponent.Released += releasedHandeler;
    }

    private void OnDisable()
    {
        pressComponent.Pressed -= pressHandler;
        releaseComponent.Released -= releasedHandeler;
    }
    private void pressHandler(object sender, EventArgs e)
    {
        lastPositionTap = pressComponent.ScreenPosition.x;
        print(lastPositionTap);
    }
    private void releasedHandeler(object sender, EventArgs e)
    {
        print(releaseComponent.ScreenPosition.x);
        if (lastPositionTap > releaseComponent.ScreenPosition.x)
        {
            print("testing");
            camera.DOMoveX(-movementPower + camera.transform.position.x, 0.1f);
        }
        else if (lastPositionTap < releaseComponent.ScreenPosition.x)
        {
            print("testing");
            camera.DOMoveX(movementPower + camera.transform.position.x, 0.1f);
        }
    }
}
