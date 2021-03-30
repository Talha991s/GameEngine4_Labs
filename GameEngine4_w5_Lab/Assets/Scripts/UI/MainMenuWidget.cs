using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWidget : MenuWidget
{
    [SerializeField] private string StartMenuName = "Load Game Menu";
    [SerializeField] private string OptionMenuName = "Options Menu";
    public void OpenStartMenu()
    {
        menuController.EnableMenu(StartMenuName);
    }

    public void OpenOptionMenu()
    {
        menuController.EnableMenu(OptionMenuName);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
