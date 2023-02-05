using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;
using DG.Tweening;
using FMOD;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private PressGesture pressComponent;
    public RaycastIfPlayerCanClick raycast;
    public Transform racineClicker;
    public MaterialManager material;
    float timer = 0;
    private void OnEnable()
    {
        pressComponent.Pressed += pressHandler;
    }
    private void OnDisable()
    {
        pressComponent.Pressed -= pressHandler;
    }
    private void Update()
    {
        try
        {
            if (timer >= Stats.Instance.real_Frequence_Auto)
                AutoClicker();
            else timer += Time.deltaTime;
        }
        catch
        {

        }
    }
    private void pressHandler(object sender, EventArgs e)
    {
        raycast.StartRaycast(Input.mousePosition);
    }
    public void Click()
    {
        print("click");
        int damage = Mathf.RoundToInt(Stats.Instance.real_Damage_Click);
        print(damage);
        if (IsThisHitACritical()) damage = damage * Mathf.RoundToInt(Stats.Instance.critique_Damage_Multiplicative);
        if ( Stats.Instance.arbre)
            Stats.Instance.AddResources1(Stats.Instance.real_Resources_Click);
        else
            Stats.Instance.AddResources2(Stats.Instance.real_Resources_Click);
        foreach (Transform racine in racineClicker)
        {
            if(racine.TryGetComponent<RacineClicker>(out RacineClicker root))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/ClickDirt");
                root.Value += damage;
                material.CollectMaterials();
            }
        }

    }
    private bool IsThisHitACritical()
    {
        if(UnityEngine.Random.Range(0, 100) < Stats.Instance.real_Critique_Percent)
        {
            print("CRITIQUE");
            return true;
        }
        return false;
    }
    private void AutoClicker()
    {
        Stats.Instance.AddResources1(Stats.Instance.real_Resources_Auto);
        foreach(Transform racine in racineClicker)
        {
            if (racine.TryGetComponent<RacineClicker>(out RacineClicker root))
            {
                root.Value += Mathf.RoundToInt(Stats.Instance.real_Damage_Auto);
                material.CollectMaterials();
            }
        }
        timer = 0;
    }
}
