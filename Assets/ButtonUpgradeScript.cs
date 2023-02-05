using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using FMOD;
public class ButtonUpgradeScript : MonoBehaviour
{
    private Stats _stats;

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Button button;
    private bool canIbuyThis = true;

    public enum what { dmg_click, rs_click, frq_auto, dmg_auto, rs_auto }
    public what whattype;

    public float multiplicateurPwrUp;


    public float multCost;
    public float brutCost;

    public int levelOfUpgrade;

    public int realRessource1ForUpgrade = 1;
    public int brutRessource1ForUpgrade = 1;
    public int realRessource2ForUpgrade = 0;
    public int brutRessource2ForUpgrade = 0;

    public Image image;
    public Sprite canBuy;
    public Sprite cantBuy;

    private void Start()
    {
        _stats = Stats.Instance;
        image = GetComponent<Image>();

        switch (whattype)
        {
            case what.dmg_click:
                text.text = $" Clic power up \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.rs_click:
                text.text = $" Clic resource up \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.frq_auto:
                text.text = $" Autoclick frequency up \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.dmg_auto:
                text.text = $" Autoclick power up \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.rs_auto:
                text.text = $" Autoclick resource up \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        if (_stats.resources1 >= realRessource1ForUpgrade && _stats.resources2 >= realRessource2ForUpgrade)
        {
            canIbuyThis = true;
            if (image.sprite != canBuy) image.sprite = canBuy;
            button.enabled = true;
        }
        else
        {
            if (image.sprite != cantBuy) image.sprite = cantBuy;
            button.enabled = false;
            canIbuyThis = false;
        }
    }
    public void UpThePrice()
    {
        brutCost *= multCost;
        realRessource1ForUpgrade = Mathf.FloorToInt(realRessource1ForUpgrade + brutCost);
        brutRessource1ForUpgrade = Mathf.FloorToInt(realRessource1ForUpgrade * _stats.Upgrade_reduction);

        if (levelOfUpgrade < 10) return;
        realRessource2ForUpgrade = Mathf.FloorToInt(realRessource2ForUpgrade + (brutCost/10));
        brutRessource2ForUpgrade = Mathf.FloorToInt(realRessource2ForUpgrade * _stats.Upgrade_reduction);
    }
    public void Buy()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Upgrade");
        switch (whattype)
        {
            case what.dmg_click:
                _stats.brut_Damage_Click += 1;
                _stats.brut_Damage_Click *= multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                levelOfUpgrade++;
                text.text = $" Clic power up + {_stats.brut_Damage_Click *= multiplicateurPwrUp} \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.rs_click:
                _stats.brut_Resources_Click += 1;
                _stats.brut_Resources_Click *= multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                levelOfUpgrade++;
                text.text = $" Clic resource up + {_stats.brut_Resources_Click *= multiplicateurPwrUp} \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.frq_auto:
                _stats.brut_Frequence_Auto += 1;
                _stats.brut_Frequence_Auto *= multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                levelOfUpgrade++;
                text.text = $" Autoclick frequency up + {_stats.brut_Frequence_Auto *= multiplicateurPwrUp} \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.dmg_auto:
                _stats.brut_Damage_Auto += 1;
                _stats.brut_Damage_Auto *= multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                levelOfUpgrade++;
                text.text = $" Autoclick power up + {_stats.brut_Damage_Auto *= multiplicateurPwrUp} \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            case what.rs_auto:
                _stats.brut_Resources_Auto += 1;
                _stats.brut_Resources_Auto *= multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                levelOfUpgrade++;
                text.text = $" Autoclick resource up + {_stats.brut_Resources_Auto *= multiplicateurPwrUp} \n minerals 1 cost : {realRessource1ForUpgrade} \n minerals 2 cost : {realRessource2ForUpgrade} ";
                break;
            default:
                UnityEngine.Debug.LogError("PTDR T NUL");
                break;
        }
    }
}
