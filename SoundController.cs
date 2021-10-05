using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Muted"))
        {
            PlayerPrefs.SetInt("Muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }
    }    

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void OnButtonPress()
    {
        if (muted)
        {
            muted = false;
            AudioListener.pause = false;
        }
        else
        {
            muted = true;
            AudioListener.pause = true;
        }
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted)
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
        else
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("Muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
    }
}
