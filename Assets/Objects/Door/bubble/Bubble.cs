using System;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public void Collect()
    {
        AudioManager.PlayOneShot(AudioClips.Instance.KeyGet);
        Destroy(gameObject);
    }
}