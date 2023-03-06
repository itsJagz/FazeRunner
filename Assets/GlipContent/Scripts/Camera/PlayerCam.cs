using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;


    public static PlayerCam ins;

    private void Awake()
    {
        ins = this;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = smoothPosition;
    }

    [Space]
    public float Amount;
    public void Shake()
    {
        transform.position = transform.position + Random.insideUnitSphere * Amount;
    }
    public void Shake(float amount)
    {
        transform.position = transform.position + Random.insideUnitSphere * amount;
    }
}
