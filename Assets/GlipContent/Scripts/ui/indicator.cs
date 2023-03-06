using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public enum display { Text, Float}
public class indicator : MonoBehaviour
{
    public display Show;
    [Space]
    public Animator anim;
    [Space]
    string _ActualText;
    Text _Text;
    TextMeshProUGUI textMeshGUI; 
    Image _Img;
    public void OnEnable()
    {
        if(GetComponent<Text>())
            _Text = GetComponent<Text>();
        if (GetComponent<TextMeshProUGUI>())
            textMeshGUI = GetComponent<TextMeshProUGUI>();
        if (GetComponent<Image>())
            _Img = GetComponent<Image>();
    }
    private void Update()
    {
        switch (Show)
        {
            case display.Text:
                if(_ActualText != "ActualValue")
                {
                    Changed();
                    _ActualText = "Here";
                    _Text.text = _ActualText;
                }
                break;
        }
    }


    void Changed()
    {

    }
}
