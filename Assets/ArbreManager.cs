using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArbreManager : Singleton<ArbreManager>
{
    public bool arbre => Stats.Instance.arbre;

    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    public Sprite sp1;
    public Sprite sp2;
    public Image image;

    public void Switch(bool a)
    {
        Stats.Instance.arbre = a;

        if(!a) { image.sprite = sp1; }
        else { image.sprite = sp2; }

        Debug.Log(Stats.Instance.level_tree1);

        SetLevel(Stats.Instance.level_tree1);
    }

    public void SetLevel(int level)
    {
        if (!arbre)
        {
            switch (level)
            {
                case 1:
                    a1.SetActive(true);
                    a2.SetActive(false);
                    a3.SetActive(false);
                    a4.SetActive(false);
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    break;

                case 2:
                    a1.SetActive(false);
                    a2.SetActive(true);
                    a3.SetActive(false);
                    a4.SetActive(false);
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    break;

                case 3:
                    a1.SetActive(false);
                    a2.SetActive(false);
                    a3.SetActive(true);
                    a4.SetActive(false);
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    break;

                case 4:
                    a1.SetActive(false);
                    a2.SetActive(false);
                    a3.SetActive(false);
                    a4.SetActive(true);
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    break;

                default:
                    break;
            }
        }
        else
        {
            switch (level)
            {
                case 1:
                    a1.SetActive(false);
                    a2.SetActive(false);
                    a3.SetActive(false);
                    a4.SetActive(false);
                    b1.SetActive(true);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    break;

                case 2:
                    a1.SetActive(false);
                    a2.SetActive(false);
                    a3.SetActive(false);
                    a4.SetActive(false);
                    b1.SetActive(false);
                    b2.SetActive(true);
                    b3.SetActive(false);
                    b4.SetActive(false);
                    break;

                case 3:
                    a1.SetActive(false);
                    a2.SetActive(false);
                    a3.SetActive(false);
                    a4.SetActive(false);
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(true);
                    b4.SetActive(false);
                    break;

                case 4:
                    a1.SetActive(false);
                    a2.SetActive(false);
                    a3.SetActive(false);
                    a4.SetActive(false);
                    b1.SetActive(false);
                    b2.SetActive(false);
                    b3.SetActive(false);
                    b4.SetActive(true);
                    break;

                default:
                    break;
            }
        }
    }
}
