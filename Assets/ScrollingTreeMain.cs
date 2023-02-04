using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;
using DG.Tweening;

public class ScrollingTreeMain : MonoBehaviour
{
    [SerializeField] private Transform objectMovement;
    [SerializeField] private float scrollSpeed = 2;
    [SerializeField] private PressGesture pressComponent;
    [SerializeField] private ReleaseGesture releaseComponent;
    private float lastPositionTap = 0;
    private bool isScreenPress = false;
    [SerializeField] private float minObjectMovement;
    [SerializeField] private float maxObjectMovement;

    private void OnEnable()
    {
        pressComponent.Pressed += pressHandler;
        releaseComponent.Released += releasedHandeler;
    }
    private void Update()
    {
        if(isScreenPress)
        {
            float cursorPosition = Input.mousePosition.y;
            float velocity = lastPositionTap - cursorPosition;
            lastPositionTap = Input.mousePosition.y;
            float vector3 = objectMovement.position.y + velocity * scrollSpeed;
            objectMovement.position = new Vector3(objectMovement.position.x,Mathf.Clamp(vector3, minObjectMovement, maxObjectMovement), objectMovement.position.z);
        }
    }
    private void OnDisable()
    {
        pressComponent.Pressed -= pressHandler;
        releaseComponent.Released -= releasedHandeler;
    }
    private void pressHandler(object sender, EventArgs e)
    {
        lastPositionTap = Input.mousePosition.y;
        isScreenPress = true;
    }
    private void releasedHandeler(object sender, EventArgs e)
    {
        isScreenPress = false;
    }
}
