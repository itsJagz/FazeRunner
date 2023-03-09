using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{

    public override void Collided()
    {
        base.Collided();
       // PlayerCam.ins.Shake();
        Destroy(gameObject);
    }

}
