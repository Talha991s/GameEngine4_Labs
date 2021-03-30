using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuWidget : MonoBehaviour
{
    [SerializeField] private string MenuName;
    protected MenuController menuController;

    private void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        if (menuController)
        {
            menuController.AddMenu(MenuName, this);
        }
        else
        {
            Debug.LogError("MenuController not found");
        }
    }
    public void ReturnToRootMenu()
    {
        if(menuController)
        {
            menuController.ReturnToRootMenu();
        }
    }
    public void EnableWidget()
    {
        gameObject.SetActive(true);
    }
    public void DisableWidget()
    {
        gameObject.SetActive(false);
    }
}
