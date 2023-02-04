using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeFruit : MonoBehaviour
{
    public Fruit fruit;

    [SerializeField] private GameObject up1Obj, up2Obj, up3Obj, up4Obj, up5Obj;
    [SerializeField]
    private TextMeshProUGUI up1Text, up2Text, up3Text, up4Text, up5Text,
        up1Cost, up2Cost, up3Cost, up4Cost, up5Cost;

    private void Update()
    {
        if (up1Cost.isActiveAndEnabled)
        {
            // verify cost , if good then green else red
        }
        if (up2Cost.isActiveAndEnabled)
        {
            // verify cost , if good then green else red
        }
        if (up3Cost.isActiveAndEnabled)
        {
            // verify cost , if good then green else red
        }
        if (up4Cost.isActiveAndEnabled)
        {
            // verify cost , if good then green else red
        }
        if (up5Cost.isActiveAndEnabled)
        {
            // verify cost , if good then green else red
        }
    }

    public void ActiveFruit()
    {
        switch (fruit.level)
        {
            case 1:
                SetUp1();
                break;
            case 2:
                SetUp1();
                SetUp2();
                break;
            case 3:
                SetUp1();
                SetUp2();
                SetUp3();
                break;
            case 4:
                SetUp1();
                SetUp2();
                SetUp3();
                SetUp4();
                break;
            case 5:
                SetUp1();
                SetUp2();
                SetUp3();
                SetUp4();
                SetUp5();
                break;
            default:
                Debug.LogError("Wrong level");
                break;
        }
    }

    void SetUp1()
    {
        up1Obj.SetActive(true);
        up1Text.text = fruit.buff1.ToString();
    }
    void SetUp2()
    {
        up2Obj.SetActive(true);
        up2Text.text = fruit.buff2.ToString();
    }
    void SetUp3()
    {
        up3Obj.SetActive(true);
        up3Text.text = fruit.buff3.ToString();
    }
    void SetUp4()
    {
        up4Obj.SetActive(true);
        up4Text.text = fruit.buff4.ToString();
    }
    void SetUp5()
    {
        up5Obj.SetActive(true);
        up5Text.text = fruit.buff5.ToString();
    }

    public void Upgrade1()
    {

    }
    public void Upgrade2()
    {

    }
    public void Upgrade3()
    {

    }
    public void Upgrade4()
    {

    }
    public void Upgrade5()
    {

    }
}
