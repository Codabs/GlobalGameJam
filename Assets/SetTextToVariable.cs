using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetTextToVariable : MonoBehaviour
{
    public bool a;
    [SerializeField] private TextMeshProUGUI text;
    private void Update()
    {
        if (a)
            text.text = Stats.Instance.resources1.ToString();
        else
            text.text = Stats.Instance.resources2.ToString();
    }
}
