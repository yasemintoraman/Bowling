using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointTextManager : MonoBehaviour
{
    private TextMeshProUGUI pointText;

    private void Start()
    {
        pointText = GetComponent<TextMeshProUGUI>();
        UpdatePointText(0);
    }

    public void UpdatePointText(int point)
    {
        pointText.text = point.ToString();
    }
}
