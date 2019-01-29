using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour {

	public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    
	void Start () {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        source.volume = 0.2F;
    }
	
    public void PlaySound() {
        source.PlayOneShot(sound);
    }

    public void PlaySound(float volume)
    {
        source.volume = volume;
        source.PlayOneShot(sound);
    }
}
