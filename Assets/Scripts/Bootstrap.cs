using UnityEngine;
using GamePush;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UIButton _resetButton;
    [SerializeField] private AdsHandler _adsHandler;
    [SerializeField] private restart _restart;
    [SerializeField] private GameAnalytics _analytics;

    [SerializeField] private Character[] _characters;

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
