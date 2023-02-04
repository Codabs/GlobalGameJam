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
    [SerializeField] private PressGesture pressComponent;
    [SerializeField] private ReleaseGesture releaseComponent;
    private float lastPositionTap = 0;
    private bool isTheInterfaceOn = false;

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
        lastPositionTap = pressComponent.ScreenPosition.y;
        print(lastPositionTap);
    }
    private void releasedHandeler(object sender, EventArgs e)
    {
        print(releaseComponent.ScreenPosition.y);
        if (lastPositionTap < releaseComponent.ScreenPosition.y && isTheInterfaceOn)
        {
            camera.DOLocalMoveY(-camera.position.y + 0.1f, 0.1f);
            isTheInterfaceOn = false;

        }
        else if (lastPositionTap > releaseComponent.ScreenPosition.y && !isTheInterfaceOn)
        {
            camera.DOLocalMoveY(camera.position.y + 0.1f, 0.1f);
            isTheInterfaceOn = true;
        }
    }
}
