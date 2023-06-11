using System;
using UnityEngine;

public interface IPresentationModel
{
    event Action OnStateChanged;

    Sprite GetIcon();

    string GetName();

    string GetDescription();

    string GetLevelText();

    float GetFillAmount();

    string GetProgressBarText();

    string GetSpeed();

    string GetStamina();

    string GetIntelligence();

    string GetDamage();

    string GetRegeneration();

    string GetDexterity();

    string GetLevelUpText();

    bool GetButtonInteractable();

    void OnLevelUpClick();

    void OnCloseClick();
}
