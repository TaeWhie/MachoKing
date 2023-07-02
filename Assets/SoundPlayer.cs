using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] soundsource;
    private AudioSource Speaker;
    // Start is called before the first frame update
    void Start()
    {
        Speaker = gameObject.GetComponent<AudioSource>();
    }

    public void playsound(int soundnum,bool nowloop)
    {
        Speaker.Stop();
        Speaker.clip = soundsource[soundnum];
        Speaker.loop = nowloop;
        Speaker.time = 0;
        Speaker.Play();
    }

}
