using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownClickableZone : MonoBehaviour
{
    [SerializeField] private float value = 5;
    public static MoveDownClickableZone Instance;
    private bool delay = true;
    private void Awake()
    {
        Instance = this;
    }
    public void MoveDown()
    {
        if (delay)
        {
            transform.transform.localPosition = new(transform.localPosition.x, transform.localPosition.y + value, transform.localPosition.z);
            delay = false;
            StartCoroutine(enumerator());
        }
    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.01f);
        delay = true;
    }
}
