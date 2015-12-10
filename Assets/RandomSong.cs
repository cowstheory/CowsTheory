using UnityEngine;
using System.Collections;

public class RandomSong : MonoBehaviour {

	public AudioClip[] songAudioClips;
	public AudioSource songAudioSource;

	void Start () {
		//
		songAudioSource = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (!songAudioSource.isPlaying) {
			playRandomSong ();
		}
	
	}
	void playRandomSong(){

		int randomNumber = Random.Range(0, songAudioClips.Length);
		if (randomNumber == 0) {
			songAudioSource.volume = 0.7F;
		} 
		else if (randomNumber == 1) {
			songAudioSource.volume = 0.5F;
		}
		songAudioSource.clip = songAudioClips [randomNumber];
		songAudioSource.Play ();		

	}
}
