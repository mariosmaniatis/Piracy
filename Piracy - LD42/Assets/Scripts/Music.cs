using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) StopMusic();
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}