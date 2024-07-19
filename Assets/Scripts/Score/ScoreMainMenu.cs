using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMainMenu : MonoBehaviour
{
    private TextMeshProUGUI _text;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Score")) PlayerPrefs.SetFloat("Score", 0);
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = "Highest Score :\n" + PlayerPrefs.GetFloat("Score").ToString();
    }

}
