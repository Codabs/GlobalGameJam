using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<RectTransform> menus = new();
    private bool isOnMainMenu = true;
    public void SwitchToXMenu(RectTransform menu)
    {
        if(isOnMainMenu)
        {
            if(!menus.Contains(menu)) menus.Add(menu);
            print(menu.rect.position);
            menu.DOLocalMove(Vector3.zero, 0.2f);
            isOnMainMenu = false;
        }
    }
    public void BackOnMainMenu()
    {
        foreach(RectTransform menu in menus)
        {
            menu.DOLocalMove(new Vector3(2979, 0), 0.2f);
            isOnMainMenu = true;
        }
    }
}
