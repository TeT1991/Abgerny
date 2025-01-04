using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanguageButton : UIButton
{
    [SerializeField] private string _language;

    public string Language => _language;

    public new Action<string> OnClick;

    public override void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(_language);
    }

}
