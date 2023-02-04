using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastIfPlayerCanClick : MonoBehaviour
{
    [SerializeField] private ClickerManager clickerManager;
    public void StartRaycast()
    {
        if (Physics.Linecast(transform.position, transform.position + Vector3.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                //clickerManager
            }
        }
    }
}
