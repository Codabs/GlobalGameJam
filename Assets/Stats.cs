using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : Singleton<Stats>
{
    public float resources1 { get; private set; }
    public float multip_Resources1;
    public void AddResources1(float resources)
    {
        resources1 += resources * multip_Resources1;
    }

    public float resources2 { get; private set; }
    public float multip_Resources2;
    public void AddResources2(float resources)
    {
        resources2 += resources * multip_Resources2;
    }

    public float real_Damage_Click 
    { 
        get { return real_Damage_Click; } 
        private set { value = multip_Damage_Click * brut_Damage_Click; } 
    }
    public float multip_Damage_Click;
    public float brut_Damage_Click;

    public float real_Resources_Click
    {
        get { return real_Resources_Click; }
        private set { value = multip_Resources_Click * brut_Resources_Click; }
    }
    public float multip_Resources_Click;
    public float brut_Resources_Click;

    public float real_Damage_Auto
    {
        get { return real_Damage_Auto; }
        private set { value = multip_Damage_Auto * brut_Damage_Auto; }
    }
    public float multip_Damage_Auto;
    public float brut_Damage_Auto;

    public float real_Resources_Auto
    {
        get { return real_Resources_Auto; }
        private set { value = multip_Resources_Auto * multip_Resources_Auto; }
    }
    public float multip_Resources_Auto;
    public float brut_Resources_Auto;

    public float real_Frequence_Auto
    {
        get { return real_Frequence_Auto; }
        private set { value = multip_Frequence_Auto * brut_Frequence_Auto; }
    }
    public float multip_Frequence_Auto;
    public float brut_Frequence_Auto;

    public int real_Nb_Branche
    {
        get { return real_Nb_Branche; }
        private set { value = Mathf.CeilToInt(multip_Nb_Branche * brut_Nb_Branche); }
    }
    public float multip_Nb_Branche;
    public float brut_Nb_Branche;

    public float real_Critique_Percent;

    public float critique_Damage_Multiplicative;

    // public float GetGlobalDamageAuto() { }

    public float Upgrade_reduction;

    // public script_de_l'upgrade ICI

    public float real_H2O
    {
        get { return real_H2O; }
        private set { value = multip_H2O * brut_H2O; }
    }
    public float multip_H2O;
    public float brut_H2O;
}
