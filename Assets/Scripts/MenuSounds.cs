using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioSource src;
    public AudioClip click;

    public void Click()
    {
        src.PlayOneShot(click);
    }
}
