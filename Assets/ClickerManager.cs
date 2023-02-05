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
    public Transform racineClicker;
    public MaterialManager material;
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
        raycast.StartRaycast(Input.mousePosition);
    }
    public void Click()
    {
        print("click");
        foreach(Transform racine in racineClicker)
        {
            if(racine.TryGetComponent<RacineClicker>(out RacineClicker root))
            {
                root.Value++;
                material.CollectMaterials();
            }
        }
    }
    private void OnDrawGizmos()
    {
    }
}
