using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class WorldObjectProps
{
    public GameObject Prefab;
    public Vector3 Rot;
    public Vector3 Offset;
}



public class WorldGenerator : MonoBehaviour
{
    [Header("Chunk Properties")]
    [Space]
    public List<GameObject> Prefabs;
    public GameObject ChunkPrefab;
    public float chunk_size;
    public int seed;
    public GameObject Target;
    public List<Vector3> GenerationCords = new List<Vector3>();

    [HideInInspector]
    public Dictionary<Vector3, GameObject> chunks = new Dictionary<Vector3, GameObject>();
    [HideInInspector]
    List<Vector3> ActiveCords = new List<Vector3>();
    public static WorldGenerator ins;
    private void Awake()
    {
        ins = this;
    }

    private void OnDisable()
    {
        foreach (var t in chunks)
            pool.Despawn(t.Value.gameObject);
        chunks.Clear();
        ActiveCords.Clear();
    }


    private void Update()
    {
        if (!Target) return;
        MakeWorldAround(Target);
    }

    public void MakeWorldAround(GameObject Target)
    {
        ActiveCords.Clear();
        for (int i = 0; i < GenerationCords.Count; i++)
        {
            var t = (get_chunk_coordinates_at(Target.transform.position) + GenerationCords[i]) * chunk_size;
            make_a_chunk_at(t);
            ActiveCords.Add(t);
        }
        var Empty = chunks.Keys.ToList().Except(ActiveCords).ToList();
        foreach (var t in Empty)
            removeChunkAt(t);
    }

    public Vector3 get_chunk_coordinates_at(Vector3 pos)
    {
        return (new Vector3(0, 0, (int)Mathf.Floor(pos.z / chunk_size)));
    }

    //Chunk Manage
    void make_a_chunk_at(Vector3 pos)
    {
        if (chunks.ContainsKey(pos))
            return;
        GameObject t = Instantiate(ChunkPrefab, pos, ChunkPrefab.transform.rotation) as GameObject;
        t.GetComponent<ChunkElement>().Init();
        chunks.Add(pos, t);
    }
    void removeChunkAt(Vector3 pos)
    {
        if (!chunks.ContainsKey(pos))
            return;
        var t = chunks[pos];
        pool.Despawn(t.gameObject);
        chunks.Remove(pos);
    }
}
