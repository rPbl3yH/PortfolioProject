using System;
using UnityEngine;

public interface IUserInfoPresentationModel
{
    Sprite GetIcon();

    string GetName();

    string GetDescription();
    
}

public interface IPresentationModel
{
    event Action OnStateChanged;
    Sprite GetIcon();

    string GetName();

    string GetDescription();

    string GetLevelText();

    float GetFillAmount();

    string GetProgressBarText();


    string GetLevelUpText();

    bool GetButtonInteractable();

    void OnLevelUpClick();

    void OnCloseClick();
}
