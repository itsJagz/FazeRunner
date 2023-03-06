using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-99)]
[System.Serializable]
public class saver
{
    
}



public class save_mng : MonoBehaviour
{
    public static save_mng ins;
    public saver CurrentSave;
    public string Key;
    string SaveStr;


    public void OnEnable()
    {
        ins = this;
        load();
    }

    public void load()
    {
        if (PlayerPrefs.HasKey("s"))
            CurrentSave = JsonUtility.FromJson<saver>(PlayerPrefs.GetString("s"));
    }

    public void save()
    {
        SaveStr = JsonUtility.ToJson(CurrentSave);
        PlayerPrefs.SetString("s", SaveStr);
    }

}
