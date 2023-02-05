using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastIfPlayerCanClick : MonoBehaviour
{
    [SerializeField] private ClickerManager clickerManager;
    public void StartRaycast(Vector2 vector2)
    {
        Vector3 vector3 = new(vector2.x/200, vector2.y/200, 2);
        GameObject game = new("point");
        game.transform.parent = transform;
        game.transform.localPosition = vector3;
        //print(game.transform.position);
        if (Physics.Linecast(transform.position, game.transform.position, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                clickerManager.Click();
            }
        }
    }
}
