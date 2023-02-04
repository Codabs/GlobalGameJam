using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : Singleton<Stats>
{
    public float resources1;
    public void AddResources1(float _resources) => resources1 += _resources;

    public float resources2;
    public void AddResources2(float _resources) => resources2 += _resources;

    public float damage_Click;
    public void AddDamageOnClick(float damage) => damage_Click += damage;


    public float resources_Click;
    public void AddresourcesOnClick(float resources) => resources_Click += resources;


    public float damage_Auto;
    public void AddDamageAuto(float damage) => damage_Auto += damage;


    public float resources_Auto;
    public void AddresourcesAuto(float resources) => resources_Auto += resources;


    public float Frequence_Auto;
    public void AddFrequenceAuto(float frequence) => Frequence_Auto += frequence;


    public int nb_branche;
    public void AddNbBranche(int nb) => nb_branche += nb;


    public float critique_percent;
    public void Addcritique(float percent) => critique_percent += percent;

    public float damage_critique;

    /// <summary>
    /// the var damage_critique is a multiply.
    /// </summary>
    /// <param name="damage"></param>
    public void AddDamage(float damage) => damage_critique += damage;

    // public float GetGlobalDamageAuto() { }

    public float Upgrade_reduction;
    public void AddReduction(float reduction) => Upgrade_reduction += reduction;

    // public script_de_l'upgrade ICI

    public float H2O;
    public void AddH2O(float h2o) => H2O += h2o;
}
