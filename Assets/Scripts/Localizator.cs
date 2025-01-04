using Lean.Localization;
using UnityEngine;

public class Localizator : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;

    private static Localizator _instance;

    private void Awake()
    {
        Init();
    }

    public void SwitchLanguage(string language)
    {
        
        _leanLocalization.SetCurrentLanguage(language);
    }

    private void Init()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
