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
   
    public Slider healthBar;

    private AudioSource drumLoopSource;
    private AudioSource bassLoopSource;
    private AudioSource keysLoopSource;
    private AudioSource fluteLoopSource;
    private AudioSource trumpetBaseLoopSource;





    // Start is called before the first frame update
    void Start()
    {
        drumLoopSource = gameObject.AddComponent<AudioSource>();
        bassLoopSource = gameObject.AddComponent<AudioSource>();
        keysLoopSource = gameObject.AddComponent<AudioSource>();
        fluteLoopSource = gameObject.AddComponent<AudioSource>();
        trumpetBaseLoopSource = gameObject.AddComponent<AudioSource>();

        drumLoopSource.clip = drumLoopClip;
        bassLoopSource.clip = bassLoopClip;
        keysLoopSource.clip = keysLoopClip;
        fluteLoopSource.clip = fluteLoopClip;
        trumpetBaseLoopSource.clip = trumpetBaseLoopClip;

        drumLoopSource.loop = true;
        bassLoopSource.loop = true;
        keysLoopSource.loop = true;
        fluteLoopSource.loop = true;
        trumpetBaseLoopSource.loop = true;

        keysLoopSource.volume = 0.0f;

        drumLoopSource.Play();
        bassLoopSource.Play();
        keysLoopSource.Play();
        fluteLoopSource.Play();
        trumpetBaseLoopSource.Play();
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
        updateVolume(healthValue, fluteLoopSource, 4);
    }


}