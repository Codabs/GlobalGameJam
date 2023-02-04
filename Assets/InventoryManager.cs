using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{

    [SerializeField] private GameObject fruitPrefab;
    public List<Cell> cell;
    [SerializeField] private List<Fruit> fruitList = new List<Fruit>();
    public void GainNewFruit()
    {
        GameObject fruit = null;
        bool pass = false;
        foreach (var item in cell)
        {
            if (item.fruit == null)
            {
                fruit = Instantiate(fruitPrefab, item.content.transform);
                item.fruit = fruit.GetComponent<Fruit>();
                pass = true;
                break;
            }
        }

        if (!pass)
        {
            Debug.Log("fruit not created");
            return;
        }

        fruitList.Add(fruit.GetComponent<Fruit>());
    }

    [SerializeField] private GameObject UpgraderReference; 
    public void OnClickFruitOpenUpgrade(Fruit fruit)
    {

    }
}
