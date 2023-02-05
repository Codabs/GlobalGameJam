using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;
using DG.Tweening;

public class ToggleMobile : MonoBehaviour
{
    [SerializeField] private TapGesture tap;
    bool flipFlop = false;
    [SerializeField] private ArbreManager arbreManager;
    private void OnEnable()
    {
        tap.Tapped += Switch;
    }
    private void OnDisable()
    {
        tap.Tapped -= Switch;
    }
    private void Switch(object sender, EventArgs e)
    {
        flipFlop = !flipFlop;
        arbreManager.Switch(flipFlop);
    }
}
