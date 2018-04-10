using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour {

	public AudioSource audioSource;
	public string soundsFolderName;
	public float minTimeBetweenSounds;
	public float maxTimeBetweenSounds;

	public float timePassed = 0f;
	public float nextSoundTime;
	public Object[] soundsFolder;
	public float timeToWaitForSoundToFinish = 0f;

	// Use this for initialization
	void Start () {

		soundsFolder = Resources.LoadAll (soundsFolderName);

		timePassed = 0f;
		nextSoundTime = Random.Range (minTimeBetweenSounds, maxTimeBetweenSounds);
		
	}
	
	// Update is called once per frame
	void Update () {

		timePassed += Time.deltaTime;
		timeToWaitForSoundToFinish -= Time.deltaTime;

		if (timePassed > nextSoundTime && timeToWaitForSoundToFinish < 0f) {
			audioSource.clip = (AudioClip) soundsFolder[Mathf.RoundToInt(Random.Range(0f, (float)soundsFolder.Length) - 1f)] as AudioClip;
			timeToWaitForSoundToFinish = audioSource.clip.length;
			audioSource.Play ();

			timePassed = 0f;
			nextSoundTime = timeToWaitForSoundToFinish + Random.Range (minTimeBetweenSounds, maxTimeBetweenSounds);
		}
	}
}
