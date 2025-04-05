using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance;
  [SerializeField] private AudioSource musicSource;
  [SerializeField] private AudioSource sfxSource;

  private void Awake()
  {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }

  public void PlayMusic(AudioClip clip)
  {
    if (clip == null) return;
    musicSource.clip = clip;
    musicSource.Play();
    sfxSource.Stop();
  }

  public AudioClip GetCurrentMusic()
  {
    return musicSource.clip;
  }

  public void PlaySound(AudioClip clip)
  {
    sfxSource.PlayOneShot(clip);
  }
}
