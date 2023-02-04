using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonUpgradeScript : MonoBehaviour
{
    [SerializeField] private Button button;
    private bool canIbuyThis = true;

    public int minRessourceForUpgrade = 0;
    public int minOxygenForUpgrade = 0;
    private int Ressource => 5;
    private int Oxygen => 5;
    private void Update()
    {
        if (Ressource >= minRessourceForUpgrade && Oxygen >= minOxygenForUpgrade)
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
        minOxygenForUpgrade = minOxygenForUpgrade + minOxygenForUpgrade / 3;
        minRessourceForUpgrade = minRessourceForUpgrade + minRessourceForUpgrade / 3;
    }
}
