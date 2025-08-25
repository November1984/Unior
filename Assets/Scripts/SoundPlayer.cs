using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    public void StartPause()
    {
        if (_audioSource.isPlaying)
            _audioSource.Pause();
        else
            _audioSource.Play();
    }
}
