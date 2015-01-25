using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundLocalManager : MonoBehaviour
{

    private class Audio
    {
        public bool available;
        public AudioSource source;
    }

    private List<Audio> AudioList;

    void Awake()
    {
        AudioList = new List<Audio>();
        AudioSource source = gameObject.AddComponent<AudioSource>();
        Audio aud = new Audio();
        aud.available = true;
        aud.source = source;
        AudioList.Add(aud);
    }


    public void PlaySound(AudioClip clip, float vol = 1, bool randomPitch = false)
    {
        Audio aud = GetAvailableSource();
        aud.available = false;
        StartCoroutine(PlayClipUsingSource(clip, aud, vol, randomPitch));
    }

    private IEnumerator PlayClipUsingSource(AudioClip clip, Audio audio, float vol, bool randomPitch)
    {
        audio.available = false;
        audio.source.volume = vol;
        if (randomPitch)
            audio.source.pitch = Random.Range(0.8f, 1.2f);
        else audio.source.pitch = 1f;

        audio.source.PlayOneShot(clip);

        yield return new WaitForSeconds(clip.length);

        audio.available = true;
    }

    private Audio GetAvailableSource()
    {
        foreach (Audio aud in AudioList)
        {
            if (aud.available)
            {
                return aud;
            }
        }

        AudioSource source = gameObject.AddComponent<AudioSource>();
        Audio newAud = new Audio();
        newAud.available = true;
        newAud.source = source;
        AudioList.Add(newAud);

        newAud.available = false;
        return newAud;
    }

}
