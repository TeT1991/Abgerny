using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LanguageButton : UIButton
{
    [SerializeField] private Button _button;
    public new Action<string> OnClick;
    public string _language;

    public override void OnPointerClick(PointerEventData eventData)
    {
        SetLanguage();
        OnClick?.Invoke(_language);
    }

    public void SetLanguage()
    {
        Debug.Log("!!!");
        if(_language == "English")
        {
            _language = "Russian";
        }

        if (_language == "Russian")
        {
            _language = "English";
        }
    }
}
