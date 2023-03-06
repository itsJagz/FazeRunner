using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-98)]
public class g_mng : MonoBehaviour
{



    public static g_mng ins;
    private void Awake()
    {
        ins = this;
    }

    public GameObject MenuState;
    public GameObject InGameState;

    private void OnEnable()
    {
        ShowMenu();
    }

    public void ShowMenu()
    {
        MenuState.SetActive(true);
        InGameState.SetActive(false);
        ui_mng.ins.ChangeState("menu");
    }

    public void BeginGame()
    {
        MenuState.SetActive(false);
        InGameState.SetActive(true);
        ui_mng.ins.ChangeState("ingame");
    }
  


}
