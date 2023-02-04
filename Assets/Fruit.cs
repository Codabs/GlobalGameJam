using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Fruit : MonoBehaviour
{
    public int level;
    public string seedShader;
    public EffectType buff1, buff2, buff3, buff4, buff5;
    public int level_buff1, level_buff2, level_buff3, level_buff4, level_buff5;
    public GameObject et1, et2, et3, et4, et5;

    private void OnEnable()
    {
        GetComponentInParent<Cell>().fruit= this;

        switch (level)
        {
            case 1:
                et1.SetActive(true);
                et2.SetActive(false);
                et3.SetActive(false);
                et4.SetActive(false);
                et5.SetActive(false);
                break;
            case 2:
                et1.SetActive(true);
                et2.SetActive(true);
                et3.SetActive(false);
                et4.SetActive(false);
                et5.SetActive(false);
                break;
            case 3:
                et1.SetActive(true);
                et2.SetActive(true);
                et3.SetActive(true);
                et4.SetActive(false);
                et5.SetActive(false);
                break;
            case 4:
                et1.SetActive(true);
                et2.SetActive(true);
                et3.SetActive(true);
                et4.SetActive(true);
                et5.SetActive(false);
                break;
            case 5:
                et1.SetActive(true);
                et2.SetActive(true);
                et3.SetActive(true);
                et4.SetActive(true);
                et5.SetActive(true);
                break;
            default:
                break;
        }

        releaseComponent.Released += releasedHandeler;

    }

    [SerializeField] private ReleaseGesture releaseComponent;
    [SerializeField] private LayerMask LayerMask;
    [SerializeField] private float rayDetection;


    private void OnDisable()
    {
        releaseComponent.Released -= releasedHandeler;
    }
    private void releasedHandeler(object sender, EventArgs e)
    {
        KdTree<Cell> kdtree = new();
        foreach(Cell cell in InventoryManager.Instance.cell)
        {
            kdtree.Add(cell);
        }
        Cell _cell = kdtree.FindClosest(transform.position);
        if (Vector3.Distance(transform.position, _cell.transform.position) < rayDetection && _cell.fruit == null)
        {
            StartCoroutine(BOUGEMIEUCONNARD(_cell));
            return;
        }
        StartCoroutine( BOUGECONNARD());

        Debug.Log("pitier");
    }

    IEnumerator BOUGECONNARD()
    {
        yield return new WaitForSeconds(0.01f);
        GetComponent<RectTransform>().localPosition = Vector3.zero;
    }
    IEnumerator BOUGEMIEUCONNARD(Cell _cell)
    {
        yield return new WaitForSeconds(0.01f);
        GetComponentInParent<Cell>().fruit = null;
        transform.parent = _cell.content.transform;
        _cell.fruit = this;
        GetComponent<RectTransform>().localPosition = Vector3.zero;
    }
}
