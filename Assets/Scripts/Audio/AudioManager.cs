using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Mixer Groups")]
    public AudioMixerGroup SFX;
    public AudioMixerGroup Music;
    public AudioMixerGroup Ambience;
    [Header("Sounds")]
    public Sound[] sounds;

    public static AudioManager shared;
    private void Awake()
    {
        if (shared == null)
        {
            shared = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
            AddToGroup(s);
        }
    }
    public void Play(string name, float volume, float pitch,float spatialblend)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.volume = volume;
                s.source.pitch = pitch;
                s.source.spatialBlend = spatialblend;
                s.source.Play();
            }
            else
            {
                Debug.LogWarning("Warning! Sound: " + name + " Could not be found! Check if the name is spelled correctly.");
            }
        }
    }


   public void Stop(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Stop();
            }
        }    
    }
 public void AddToGroup(Sound s)
{
        switch (s.group)
        {
            case audiogroup.SFX:
                s.source.outputAudioMixerGroup = SFX;
                break;
            case audiogroup.Music:
                s.source.outputAudioMixerGroup = Music;
                break;
            case audiogroup.Ambient:
                s.source.outputAudioMixerGroup = Ambience;
                break;
            default:
                Debug.LogError("Error! Group not found.");
                break;
        }

    }
}


        



