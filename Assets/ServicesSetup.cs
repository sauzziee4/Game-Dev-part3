using System;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.CloudSave.Models;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;

public class ServicesSetup : MonoBehaviour
{
    #region FIELDS

    [SerializeField]
    private TMP_Text _highscoreText;
    [SerializeField]
    private Button _loadButton;

    #endregion
    
    
    
    #region UNITY METHODS

    private async void Awake()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += OnSignIn;
        AuthenticationService.Instance.SignInFailed += OnSignInFailed;
        AuthenticationService.Instance.SignedOut += OnSignOut;

        await AuthenticationService.Instance.SignInAnonymouslyAsync();


        await CloudSave.SaveData();
    }

    private void OnEnable()
    {
        _loadButton.onClick.AddListener(OnLoadButtonClicked);
    }

    private void OnDisable()
    {
        _loadButton.onClick.RemoveListener(OnLoadButtonClicked);
    }

    #endregion

    #region SERVICES METHODS

    private void OnSignIn()
    {
        print("Signed In Successfully.");
        print(AuthenticationService.Instance.PlayerId);
        print(AuthenticationService.Instance.AccessToken);
    }

    private void OnSignInFailed(RequestFailedException exception)
    {
        print("Signed In Failed.");
        print(exception.Message);
    }

    private void OnSignOut()
    {
        print("Signed Out Successfully");
    }

    #endregion

    #region BUTTON METHODS

    private async void OnLoadButtonClicked()
    {
        Item data = await CloudSave.LoadData();
        _highscoreText.SetText(data.Value.GetAs<int>().ToString());
        print(_highscoreText.text); 
    }

    #endregion
}