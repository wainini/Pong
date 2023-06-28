using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Menu : MonoBehaviour
{
    public Action OnStartGame;

    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject mainMenu;

    public void BackToMenu()
    {
        winMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
        mainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
