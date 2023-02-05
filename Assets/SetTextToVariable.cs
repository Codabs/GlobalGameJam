using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetTextToVariable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private void Update()
    {
        text.text = Stats.Instance.resources1.ToString();
    }
}
