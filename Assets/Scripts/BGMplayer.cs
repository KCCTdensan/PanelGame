using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer : MonoBehaviour {

    [SerializeField] AudioClip IntroClip;
    [SerializeField] AudioClip LoopClip;

    AudioSource IntroSource;
    AudioSource LoopSource;

	// Use this for initialization
	void Start () {
        IntroSource = gameObject.AddComponent<AudioSource>();
        LoopSource = gameObject.AddComponent<AudioSource>();

        IntroSource.clip = IntroClip;
        IntroSource.loop = false;
        IntroSource.playOnAwake = false;

        LoopSource.clip = LoopClip;
        LoopSource.loop = true;
        LoopSource.playOnAwake = false;

        playBGM();
    }

// Update is called once per frame
    void playBGM () {
        if (IntroSource == null || LoopSource == null)
        {
            return;
        }

        IntroSource.Play();
        LoopSource.PlayScheduled(AudioSettings.dspTime + IntroClip.length);
    }

    public void StopBGM()
    {
        if (IntroSource == null || LoopSource == null)
        {
            return;
        }

        if (IntroSource.isPlaying)
        {
            IntroSource.Stop();
        }
        else if (LoopSource.isPlaying)
        {
            LoopSource.Stop();
        }
    }
}
