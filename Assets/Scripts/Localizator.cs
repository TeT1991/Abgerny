using Lean.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Localizator : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;
    [SerializeField] private Sprite[] _flags;

    private static Localizator _instance;

    public Action LanguageChaged; 

    private void Awake()
    {
        Init();
    }

    public void SwitchLanguage(string language)
    {
        Debug.Log(language);
        _leanLocalization.SetCurrentLanguage(language);
        Debug.Log(_leanLocalization.CurrentLanguage);

    }

    private void Init()
    {
        //if (_instance == null)
        //{
        //    _instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }
}
