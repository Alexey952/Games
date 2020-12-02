using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Setting : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;

    void Start()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(QualitySettings.names.ToList());
        dropdown.value = QualitySettings.GetQualityLevel();
    }
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
    }
}
