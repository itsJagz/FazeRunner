using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkElement : MonoBehaviour
{

    [Header("Data")]
    public List<GameObject> ChunkObjects = new List<GameObject>();
    [Header("Spawn Options")]
    [Space]
    public List<GameObject> BG;
    public List<GameObject> Obstacles;


    public void Init()
    {
        foreach (var t in BG)
            t.SetActive(false);
        foreach (var t in Obstacles)
            t.SetActive(false);

        BG[Random.Range(0,BG.Count)].SetActive(true);
        Obstacles[Random.Range(0, Obstacles.Count)].SetActive(true);
        return;
    }

}
