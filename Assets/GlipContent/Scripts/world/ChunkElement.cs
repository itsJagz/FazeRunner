using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkElement : MonoBehaviour
{

    [Header("Data")]
    public List<GameObject> ChunkObjects = new List<GameObject>();
    [Header("Spawn Options")]
    [Space]
    public GameObject[] stamper;
    public Transform ChunkObjectsParent;
    public LayerMask GroundLayer;
    public LayerMask ObstacleLayer;
    RaycastHit hit;
    [Space]
    public bool OverLapMetod = false;
    public bool NoiseMethod = false;
    public bool StrictMethod = true;
    public List<GameObject> Obstacles;
    public void Init(List<GameObject> Prefabs,int Seed)
    {

        if (StrictMethod)
        {
            var judge = Mathf.PerlinNoise(transform.position.magnitude, Seed)*100;
            print(judge);
            Obstacles[((int)judge) % Obstacles.Count].SetActive(true);
            return;
        }

        var C = 0;
        foreach (var t in stamper)
        {
            C++;
            t.transform.name = C.ToString();

            if (OverLapMetod)
            {
                if (Physics.Raycast(t.transform.position, Vector3.down, out hit, Mathf.Infinity, GroundLayer))
                {
                    var to = Physics.OverlapSphere(hit.point, 40f, ObstacleLayer);
                    if (to.Length < 2)
                    {
                        var objToSpawn = Prefabs[Random.Range(0, Prefabs.Count)];
                        var n = pool.Spawn(objToSpawn, hit.point, Quaternion.Euler(objToSpawn.transform.rotation.x, 90f * (int)Random.Range(0, 4), objToSpawn.transform.rotation.z));
                        n.transform.SetParent(ChunkObjectsParent, true);
                        n.GetComponent<AnEntity>().Id = C;
                        ChunkObjects.Add(n);
                    }
                }
            }
            if(NoiseMethod)
            {
                var judge = Mathf.PerlinNoise(t.transform.position.magnitude, Seed);
                print(judge);
                if (judge <= 0.3f && judge >= 0.2f)
                if (Physics.Raycast(t.transform.position, Vector3.down, out hit, Mathf.Infinity, GroundLayer))
                {
                    var objToSpawn = Prefabs[Random.Range(0, Prefabs.Count)];
                    var n = pool.Spawn(objToSpawn, hit.point, Quaternion.Euler(objToSpawn.transform.rotation.x, 90f * (int)Random.Range(0, 4), objToSpawn.transform.rotation.z));
                    n.transform.SetParent(ChunkObjectsParent, true);
                    n.GetComponent<AnEntity>().Id = C;
                    ChunkObjects.Add(n);
                }
            }
        }
    }

    //Operational
    [ContextMenu("MakeChunkObjects")]
    public void MakeStamps()
    {
     
    }
    [ContextMenu("DeleteChunkObjects")]
    public void DeletePrefabs()
    {
        foreach (var t in ChunkObjects)
            pool.Despawn(t);
        ChunkObjects.Clear();
    }

}
