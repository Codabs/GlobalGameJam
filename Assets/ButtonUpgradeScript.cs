using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonUpgradeScript : MonoBehaviour
{
    private Stats _stats;

    [SerializeField] private Button button;
    private bool canIbuyThis = true;

    public enum what { dmg_click, rs_click, frq_auto, dmg_auto, rs_auto }
    public what whattype;

    public float multiplicateurPwrUp;

    public int levelOfUpgrade;

    public int realRessource1ForUpgrade = 1;
    public int brutRessource1ForUpgrade = 1;
    public int realRessource2ForUpgrade = 0;
    public int brutRessource2ForUpgrade = 0;

    private void Start()
    {
        _stats = Stats.Instance;
    }
    private void Update()
    {
        if (_stats.resources1 >= realRessource1ForUpgrade && _stats.resources2 >= realRessource2ForUpgrade)
        {
            canIbuyThis = true;
            button.enabled = true;
            print("buy");
        }
        else
        {
            button.enabled = false;
            canIbuyThis = false;
            print("cantbuy");
        }
    }
    public void UpThePrice()
    {
        realRessource1ForUpgrade = Mathf.FloorToInt(realRessource1ForUpgrade * 1.35f) +1;
        brutRessource1ForUpgrade = Mathf.FloorToInt(realRessource1ForUpgrade * _stats.Upgrade_reduction);

        if (levelOfUpgrade < 100) return;
        realRessource2ForUpgrade = Mathf.FloorToInt(realRessource2ForUpgrade * 1.35f) + 1;
        brutRessource2ForUpgrade = Mathf.FloorToInt(realRessource2ForUpgrade * _stats.Upgrade_reduction);
    }
    public void Buy()
    {
        switch (whattype)
        {
            case what.dmg_click:
                _stats.brut_Damage_Click += multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                break;
            case what.rs_click:
                _stats.brut_Resources_Click += multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                break;
            case what.frq_auto:
                _stats.brut_Frequence_Auto += multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                break;
            case what.dmg_auto:
                _stats.brut_Damage_Auto += multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                break;
            case what.rs_auto:
                _stats.brut_Resources_Auto += multiplicateurPwrUp;
                _stats.AddResources1(-realRessource1ForUpgrade);
                _stats.AddResources2(-realRessource2ForUpgrade);
                UpThePrice();
                break;
            default:
                Debug.LogError("PTDR T NUL");
                break;
        }
    }
}
