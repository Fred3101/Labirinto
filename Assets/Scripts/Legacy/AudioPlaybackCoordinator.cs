using System;
using System.Collections.Generic;
using UnityEngine;

public static class AudioPlaybackCoordinator
{
    // Names of the clips currently stored in Assets/Sounds/SFX.
    private static readonly HashSet<string> sfxClipNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "passos_01",
        "passos_02",
        "passos_03",
        "passos_04",
        "passos_todos",
        "reset",
        "spooktune",
        "spookwave",
        "tyle",
        "vitória"
    };

    private static readonly HashSet<AudioSource> sfxSources = new HashSet<AudioSource>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetState()
    {
        sfxSources.Clear();
    }

    public static void Play(AudioSource source)
    {
        if (source == null || source.clip == null)
        {
            return;
        }

        if (IsSfx(source.clip))
        {
            sfxSources.Add(source);
        }
        else
        {
            InterruptNonSfxAudio(source);
        }

        source.Play();
    }

    public static void PlayDelayed(AudioSource source, float delay)
    {
        if (source == null || source.clip == null)
        {
            return;
        }

        if (IsSfx(source.clip))
        {
            sfxSources.Add(source);
        }
        else
        {
            InterruptNonSfxAudio(source);
        }

        source.PlayDelayed(delay);
    }

    public static void PlayOneShot(AudioSource source, AudioClip clip)
    {
        if (source == null || clip == null)
        {
            return;
        }

        if (IsSfx(clip))
        {
            sfxSources.Add(source);
        }
        else
        {
            InterruptNonSfxAudio(source);
        }

        source.PlayOneShot(clip);
    }

    private static void InterruptNonSfxAudio(AudioSource requestedSource)
    {
        sfxSources.Remove(requestedSource);
        sfxSources.RemoveWhere(source => source == null);

        AudioSource[] sources = UnityEngine.Object.FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource source in sources)
        {
            if (source == requestedSource)
            {
                source.Stop();
            }
            else if (sfxSources.Contains(source))
            {
                continue;
            }
            else if (IsSfx(source.clip))
            {
                sfxSources.Add(source);
            }
            else
            {
                source.Stop();
            }
        }
    }

    private static bool IsSfx(AudioClip clip)
    {
        return clip != null && sfxClipNames.Contains(clip.name);
    }
}
