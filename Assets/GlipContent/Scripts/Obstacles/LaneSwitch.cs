using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitch : MonoBehaviour
{
    public Vector3[] lanes;
    private void OnEnable()
    {
         transform.localPosition = lanes[Random.Range(0, lanes.Length)];
    }
}
