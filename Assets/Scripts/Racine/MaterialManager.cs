using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public int NumberOfRootAttacking;
    public int MaterialsCollectedPerRacines;
    public int TotalMaterialsCollectedPerClick;

    public int RacinesNeededForNextPalier;
    public int RacinesInPalier;
    public int Palier;

    /*public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CollectMaterials();
        }
    }*/

    public void CollectMaterials()
    {
        TotalMaterialsCollectedPerClick = 0;

        for (int i = this.gameObject.transform.childCount - NumberOfRootAttacking; i < this.gameObject.transform.childCount; i++)
        {
            if(i < 0)
            {
                i = 0;
            }

            if(this.gameObject.transform.GetChild(i).GetComponent<RacineClicker>().HasDuplicated == false)
            {
                TotalMaterialsCollectedPerClick += MaterialsCollectedPerRacines;
            }

        }

        RacinesNeededForNextPalier = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1).GetComponent<RacineClicker>().RacinesNeededForNextPalier;

        RacinesInPalier = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1).GetComponent<RacineClicker>().RacinesInPalier;

        Palier = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1).GetComponent<RacineClicker>().Palier;

    }
}
