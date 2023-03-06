using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pl")
            Collided();
    }

    public virtual void Collided()
    {

    }
}
