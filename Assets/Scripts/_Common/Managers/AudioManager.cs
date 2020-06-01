using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceEffect;
    [SerializeField] private AudioSource audioSourceBg;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioClip audioClipBg;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayBgMusic();
    }
    public void PlayMusic(int clipIndex)
    {
        audioSourceEffect.clip = audioClips[clipIndex];
        audioSourceEffect.Play();
    }

    public void PlayBgMusic()
    {
        audioSourceBg.clip = audioClipBg;
        audioSourceBg.Play();
    }
}
