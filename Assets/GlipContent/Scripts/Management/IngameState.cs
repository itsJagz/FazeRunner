using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameState : MonoBehaviour
{
    public Transform StartPos;
    public GameObject Player;


    private void OnEnable()
    {
        Player.transform.position = StartPos.position;
        Player.transform.rotation = StartPos.rotation;

        Player.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
