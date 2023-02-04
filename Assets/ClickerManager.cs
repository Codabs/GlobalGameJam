using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;
using DG.Tweening;


public class ClickerManager : MonoBehaviour
{
    [SerializeField] private PressGesture pressComponent;
    public RaycastIfPlayerCanClick raycast;

    private void OnEnable()
    {
        pressComponent.Pressed += pressHandler;
    }

    private void OnDisable()
    {
        pressComponent.Pressed -= pressHandler;
    }
    private void pressHandler(object sender, EventArgs e)
    {
        raycast.StartRaycast();
    }
}
