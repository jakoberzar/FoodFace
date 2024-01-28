using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicEngine : MonoBehaviour
{

    public AudioClip drumLoopClip;
    public AudioClip bassLoopClip;
    public AudioClip keysLoopClip;
    public AudioClip fluteLoopClip;
    public AudioClip trumpetBaseLoopClip;
    public AudioClip trumpetHarmony1LoopClip;
    public AudioClip trumpetHarmony2LoopClip;

    public Slider healthBar;

    private AudioSource drumLoopSource;
    private AudioSource bassLoopSource;
    private AudioSource keysLoopSource;
    private AudioSource fluteLoopSource;
    private AudioSource trumpetBaseLoopSource;
    private AudioSource trumpetHarmony1LoopSource;
    private AudioSource trumpetHarmony2LoopSource;





    // Start is called before the first frame update
    void Start()
    {
        drumLoopSource = gameObject.AddComponent<AudioSource>();
        bassLoopSource = gameObject.AddComponent<AudioSource>();
        keysLoopSource = gameObject.AddComponent<AudioSource>();
        fluteLoopSource = gameObject.AddComponent<AudioSource>();
        trumpetBaseLoopSource = gameObject.AddComponent<AudioSource>();
        trumpetHarmony1LoopSource = gameObject.AddComponent<AudioSource>();
        trumpetHarmony2LoopSource = gameObject.AddComponent<AudioSource>();

        drumLoopSource.clip = drumLoopClip;
        bassLoopSource.clip = bassLoopClip;
        keysLoopSource.clip = keysLoopClip;
        fluteLoopSource.clip = fluteLoopClip;
        trumpetBaseLoopSource.clip = trumpetBaseLoopClip;
        trumpetHarmony1LoopSource.clip = trumpetHarmony1LoopClip;
        trumpetHarmony2LoopSource.clip = trumpetHarmony2LoopClip;

        drumLoopSource.loop = true;
        bassLoopSource.loop = true;
        keysLoopSource.loop = true;
        fluteLoopSource.loop = true;
        trumpetBaseLoopSource.loop = true;
        trumpetHarmony1LoopSource.loop = true;
        trumpetHarmony2LoopSource.loop = true;

        keysLoopSource.volume = 0.0f;

        drumLoopSource.Play();
        bassLoopSource.Play();
        keysLoopSource.Play();
        fluteLoopSource.Play();
        trumpetBaseLoopSource.Play();
        trumpetHarmony1LoopSource.Play();
        trumpetHarmony2LoopSource.Play();
    }

    void updateVolume(float healthValue, AudioSource audioSource, int index)

    {
        float volume;

        if (healthValue == 0)
        {
            volume = 0;
        }
        else if (healthValue > ((index + 1) * 0.2f))
        {
            volume = 1;
        }
        else
        {
            volume = (healthValue - index * 0.2f) / 0.2f;
        }

        audioSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        float healthValue = healthBar.value;
        updateVolume(healthValue, bassLoopSource, 0);
        updateVolume(healthValue, keysLoopSource, 1);
        updateVolume(healthValue, trumpetBaseLoopSource, 2);
        updateVolume(healthValue, trumpetHarmony1LoopSource, 3);
        updateVolume(healthValue, trumpetHarmony2LoopSource, 4);
        updateVolume(healthValue, fluteLoopSource, 4);
    }


}