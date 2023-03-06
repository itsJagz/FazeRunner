using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class g_settings : MonoBehaviour
{
    public static g_settings ins;
    [Space]
    public AudioMixer audioMixer;
    public void Awake()
    {
        ins = this;
    }

}
