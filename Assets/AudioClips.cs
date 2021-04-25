using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "Custom/Audio Clips")]
public class AudioClips : ScriptableObject
{
    private static AudioClips _instance;

    public static AudioClips Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<AudioClips>("AudioClips");
            return _instance;
        }
    }
    
    public AudioClip TridentHit;
    public AudioClip Goal;
    public AudioClip FishDie;
    public AudioClip RockMove;
    public AudioClip KeyGet;
    public AudioClip DoorOpen;
    public AudioClip Restart;
    public AudioClip MenuBlip;
}