using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBackground : MonoBehaviour
{
    public static DuplicateBackground Instance = null;
    public Vector3 moveForce = Vector3.zero;
    private Vector3 value = Vector3.zero;
    [SerializeField] List<GameObject> prefab;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else this.enabled = false;
    }
    public void NewBackground()
    {
        value += moveForce;
        Transform t = GameObject.Instantiate(prefab[Random.Range(0, prefab.Count )], transform).transform;
        t.localPosition = value;
        t.localScale = Vector3.one;
    }
}
