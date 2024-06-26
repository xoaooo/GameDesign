using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] AudioSource soundFXObject;
    [SerializeField] AudioSource musicObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void PlaySFXClip(AudioClip audio, Transform spawntransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawntransform.position, Quaternion.identity);
        audioSource.clip = audio;
        audioSource.volume = volume;

        audioSource.loop = false;   
        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSFXClip(AudioClip[] audios, Transform spawntransform, float volume)
    {
        int rand = Random.Range(0, audios.Length);
        AudioClip audio = audios[rand];
        AudioSource audioSource = Instantiate(soundFXObject, spawntransform.position, Quaternion.identity);
        audioSource.clip = audio;
        audioSource.volume = volume;

        audioSource.loop = false;
        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayMusic(AudioClip music, Transform spawntransform, float volume)
    {
        AudioSource audioSource = Instantiate(musicObject, spawntransform.position, Quaternion.identity);
        audioSource.clip = music;
        audioSource.volume = volume;

        audioSource.loop = true;
        audioSource.Play();

    }
}