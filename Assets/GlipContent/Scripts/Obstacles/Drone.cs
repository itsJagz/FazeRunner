using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Interactable
{
    public bool move = true;
    public Transform pointA, pointB;
    public float speed;
    public Animator anim;
    float Timer;

    private void OnEnable()
    {
        walkingfront = true;
        anim?.Play("walk");
    }
    bool walkingfront;
    void Update()
    {
        var dest = !walkingfront ? pointA.position : pointB.position;
        if(move)transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);

        Timer += Time.deltaTime;
        if(Vector3.Distance(transform.position, dest) < 0.1f)
        {
            Timer = 0;
            if (anim)
            {
                if (walkingfront) anim?.Play("walk");
                else anim?.Play("walkback");
            }
            walkingfront = !walkingfront;
        }
    }
    public override void Collided()
    {
        base.Collided();
        anim.Play("walkback");
        PlayerMng.ins.GetHitOnce();
    }
}
