using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public enum uistate { menu = 0,ingame =1 }
[DefaultExecutionOrder(-98)]
public class ui_mng : MonoBehaviour
{
    public static ui_mng ins;

    public uistate State;
    public uistate PrevState;
    public GameObject[] StatesGO;

    private void Awake()
    {
        ins = this;
    }

    private void OnEnable()
    {
        foreach(GameObject t in StatesGO)
            t.SetActive(false);
        ChangeState(uistate.menu);
    }
   

    public void ChangeState(string thisOne)
    {
        ChangeState((uistate) System.Enum.Parse(typeof(uistate),thisOne));
    }
  
    public void ChangeState(uistate thisOne)
    {
        StatesGO.Where(a=>a.name == State.ToString()).FirstOrDefault().SetActive(false);
        PrevState = State;
        State = thisOne;
        StatesGO.Where(a => a.name == State.ToString()).FirstOrDefault().SetActive(true);
    }
}
