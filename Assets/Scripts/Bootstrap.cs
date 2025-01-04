using UnityEngine;
using GamePush;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UIButton _resetButton;
    [SerializeField] private AdsHandler _adsHandler;
    [SerializeField] private restart _restart;
    [SerializeField] private GameAnalytics _analytics;

    [SerializeField] private Character[] _characters;
    [SerializeField] private LanguageButton[] _languageButtons;

    private Localizator _localizator;

    private void Awake()
    {
        Init();
    }

    private void OnPluginReady()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _resetButton.OnClick += _adsHandler.ShowFullscreen;
        _resetButton.OnClick += _analytics.CountLevelReset;
        _adsHandler.OnFullScreenClose += _restart.ResetScene;

        foreach (var character in _characters)
        {
            character.Activated += _analytics.CountButtonUse;
        }

        _localizator = FindAnyObjectByType<Localizator>();

        if (_localizator != null)
        {

            foreach (var button in _languageButtons)
            {
                button.OnClick += _localizator.SwitchLanguage;
            }
        }
    }

    private void UnSubscribe()
    {
        _resetButton.OnClick -= _adsHandler.ShowFullscreen;
        _resetButton.OnClick -= _analytics.CountLevelReset;
        _adsHandler.OnFullScreenClose -= _restart.ResetScene;
        foreach (var character in _characters)
        {
            character.Activated -= _analytics.CountButtonUse;
        }

        if( _localizator != null )
        {
            foreach (var button in _languageButtons)
            {
                button.OnClick -= _localizator.SwitchLanguage;
            }
        }
    }

    private void OnDestroy()
    {
        GP_Init.OnReady -= OnPluginReady;
        UnSubscribe();
    }

    private void Init()
    {
        if (GP_Init.isReady == false)
        {
            GP_Init.OnReady += OnPluginReady;
            return;
        }

        OnPluginReady();
    }
}
