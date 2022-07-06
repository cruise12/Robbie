using UnityEngine;
public class Audiomanager : MonoBehaviour
{
    static Audiomanager current;
    [Header("ª∑æ≥…˘“Ù")]
    public AudioClip ambientClip;
    public AudioClip musicClip;
    [Header("character")]
    public AudioClip[] walkStepClips;//“Ù∆µ¥¢¥Ê
    public AudioClip[] crouchStepClips;
    public AudioClip jumpClip;
    public AudioClip jumpVoiceClip;
    AudioSource ambientSource;
    AudioSource musicSource;
    AudioSource fxSource;
    AudioSource playerSource;
    AudioSource voiceSource;
    public AudioClip deathfxClip;
    public AudioClip deathVoiceClip;
    public AudioClip deathClip;
    public AudioClip orbFxClip;
    public AudioClip orbVoiceClip;
    public AudioClip doorfxclip;
        
    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);
        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource= gameObject.AddComponent<AudioSource>();
        fxSource= gameObject.AddComponent<AudioSource>();
        playerSource= gameObject.AddComponent<AudioSource>();
        voiceSource= gameObject.AddComponent<AudioSource>();
        StartLevelAduio();
    }
    public static void Audio(AudioSource audio,AudioClip clip)
    {
        audio.clip = clip;       
        audio.Play();      
    }
    void StartLevelAduio()
    {   
        current.ambientSource.clip = current.ambientClip;
        current.ambientSource.loop = true;
        this.ambientSource.Play();
        current.musicSource.clip = current.musicClip;
        current.musicSource.loop = true;
        this.musicSource.Play();
    }
    public static void Startdoor()
    {
        current.fxSource.clip = current.doorfxclip;
        current.fxSource.PlayDelayed(1.1f);
    }
    public static void PlayerFootstepAudio()
    {
        int index = Random.Range(0, current.walkStepClips.Length);
        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
    }
    public static void PlayCrouchFootstepAudio()
    {
        int index = Random.Range(0, current.crouchStepClips.Length);
        current.playerSource.clip = current.crouchStepClips[index];
        current.playerSource.Play();

    }
    public static void Playjumpaduio()
    {
        current.playerSource.clip = current.jumpClip;
        current.playerSource.Play();
        current.voiceSource.clip = current.jumpVoiceClip;
        current.voiceSource.Play();
    }
    public static void PlayDeathAudio()
    {
        current.playerSource.clip = current.deathClip;
        current.playerSource.Play();
        current.voiceSource.clip = current.deathVoiceClip;
        current.voiceSource.Play();
        current.fxSource.clip = current.deathfxClip;
        current.fxSource.Play();
    }   
    public static void playOrbAudio()
    {
        current.fxSource.clip = current.orbFxClip;
        current.fxSource.Play();
        current.voiceSource.clip = current.orbVoiceClip;
        current.voiceSource.Play();
    }
}
