using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodestroy : MonoBehaviour
{
    public float Life;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= Life)
        {
            pool.Despawn(gameObject);
            timer = 0;
        }
    }
}
