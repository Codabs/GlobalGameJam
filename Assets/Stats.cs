using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : Singleton<Stats>
{
    private void Awake()
    {
        if (level_tree1 == 0)
        {
            AddLevelTree();
        }
    }

    public bool arbre;

    public int level_tree1 { get; private set; } = 0;
    public void AddLevelTree() { 
        if (level_tree1 < 4) level_tree1 += 1;
        ArbreManager.Instance.SetLevel(level_tree1);
        explosc.Instance.lvlup();
    }

    [SerializeField] private float _resources1;
    public float resources1 
    { 
        get { return _resources1; }
        private set { _resources1 = value; }
    }
    public float multip_Resources1;
    public void AddResources1(float resources)
    {
        resources1 += resources * multip_Resources1;
    }

    [SerializeField] private float _resources2;
    public float resources2
    {
        get { return _resources2; }
        private set { _resources2 = value; }
    }
    public float multip_Resources2;
    public void AddResources2(float resources)
    {
        resources2 += resources * multip_Resources2;
    }

    [SerializeField] private float _real_Damage_Click;
    public float real_Damage_Click 
    { 
        get { return _real_Damage_Click; } 
        private set { _real_Damage_Click = multip_Damage_Click * brut_Damage_Click; } 
    }
    public float multip_Damage_Click;
    public float brut_Damage_Click;

    [SerializeField] private float _real_Resources_Click;
    public float real_Resources_Click
    {
        get { return _real_Resources_Click; }
        private set { _real_Resources_Click = multip_Resources_Click * brut_Resources_Click; }
    }
    public float multip_Resources_Click;
    public float brut_Resources_Click;

    [SerializeField] private float _real_Damage_Auto;
    public float real_Damage_Auto
    {
        get { return _real_Damage_Auto; }
        private set { _real_Damage_Auto = multip_Damage_Auto * brut_Damage_Auto; }
    }
    public float multip_Damage_Auto;
    public float brut_Damage_Auto;

    [SerializeField] private float _real_Resources_Auto;
    public float real_Resources_Auto
    {
        get { return _real_Resources_Auto; }
        private set { _real_Resources_Auto = multip_Resources_Auto * multip_Resources_Auto; }
    }
    public float multip_Resources_Auto;
    public float brut_Resources_Auto;

    [SerializeField] private float _real_Frequence_Auto;
    public float real_Frequence_Auto
    {
        get { return _real_Frequence_Auto; }
        private set { _real_Frequence_Auto = multip_Frequence_Auto * brut_Frequence_Auto; }
    }
    public float multip_Frequence_Auto;
    public float brut_Frequence_Auto;

    [SerializeField] private int _real_Nb_Branche;
    public int real_Nb_Branche
    {
        get { return _real_Nb_Branche; }
        private set { _real_Nb_Branche = Mathf.CeilToInt(multip_Nb_Branche * brut_Nb_Branche); }
    }
    public float multip_Nb_Branche;
    public float brut_Nb_Branche;

    public float real_Critique_Percent;

    public float critique_Damage_Multiplicative;

    // public float GetGlobalDamageAuto() { }

    /// <summary>
    /// Only 1 to 0.75
    /// </summary>
    /// 
    [SerializeField] private float _Upgrade_reduction;
    public float Upgrade_reduction 
    { 
        get { return _Upgrade_reduction; }
        set { _Upgrade_reduction = Mathf.Clamp(value, 0.75f, 1f); }
    }

    // public script_de_l'upgrade ICI

    public float real_H2O
    {
        get { return real_H2O; }
        private set { value = multip_H2O * brut_H2O; }
    }
    public float multip_H2O;
    public float brut_H2O;
}
