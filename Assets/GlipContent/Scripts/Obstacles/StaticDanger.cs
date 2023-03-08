using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDanger : Interactable
{
    public override void Collided()
    {
    base.Collided();
    PlayerMng.ins.GetHitOnce();
    }
}
