using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Menu : MonoBehaviour
{
    public Action OnStartGame;
    public Action OnMainMenu;

    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject mainMenu;

    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gm.currentBall != null)
        {
            if (mainMenu.activeInHierarchy)
            {
                CloseMainMenu();
            }
            else
            {
                OpenMainMenu();
            }
        }
        
    }

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

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        OnMainMenu?.Invoke();
    }

    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
        OnMainMenu?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
