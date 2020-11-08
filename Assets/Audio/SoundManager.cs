using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : GameBehaviour
{
	[SerializeField] private AudioSource AS_Ambient;
	[SerializeField] private AudioSource AS_Music;
	public AudioClip attackPlayer;
	public AudioClip coffee_loop;
	public List<AudioClip> agro; 
	public AudioMixerGroup mixer;

	public List<AudioSource> sources;

	bool bPlay = false;

	private void Awake()
	{
		DoInTime(TurnOnSounds, 2);
	}

	public void TurnOnSounds()
	{
		bPlay = true;
		//PlayMusic();
	}

	public enum ESound
	{
		eCollect,
		eDenial,
		eSpawn,
		eHurt,
		eCoffee,
		eUpgradeStarted,
		eUpgradeDone,
		eUpgradeFailed,
		eAgro,

	}
	ESound eSound;

	public void PlayMusic()
	{
		AS_Ambient.Play();
		//AS_Music.Play();
	}

	private void Update()
	{
		//if (AS_Ambient.isPlaying);




		//foreach (AudioSource source in sources)
		{
			/*if (!source.loop && !source.isPlaying)
				sources.Remove;*/
		}
	}

	public void StopSound(ESound sound)
	{
		if (!bPlay)
			return;

		switch (sound)
		{
			case ESound.eCollect:
				break;
			case ESound.eDenial:
				break;
			case ESound.eSpawn:
				break;
			case ESound.eHurt:
				break;
			case ESound.eCoffee:
				StopAudio(coffee_loop);
				break;
			case ESound.eUpgradeStarted:
				break;
			case ESound.eUpgradeDone:
				break;
			case ESound.eUpgradeFailed:
				break;
			case ESound.eAgro:
				break;
			default:
				break;
		}
	}


	public void PlaySound(ESound sound)
	{
		if (!bPlay)
			return;

		switch (sound)
		{
			case ESound.eCollect:
				break;
			case ESound.eDenial:
				break;
			case ESound.eSpawn:
				break;
			case ESound.eHurt:
				break;
			case ESound.eCoffee:
				PlayAudio(coffee_loop, true);
				break;
			case ESound.eUpgradeStarted:
				break;
			case ESound.eUpgradeDone:
				break;
			case ESound.eUpgradeFailed:
				break;
			case ESound.eAgro:
				
				PlayAudio(agro[Random.Range(0, 9)]);
				break;
			default:
				break;
		}
	}

	void PlayAudio(AudioClip clip, bool bLoop = false)
	{
		foreach (AudioSource source in sources)
		{
			if (source.clip == clip)
			{
				if (bLoop && !source.isPlaying)
					source.UnPause();
				if (!bLoop && !source.isPlaying)
					source.Play();

				return;
			}
		}
		GameObject soundGameObject = new GameObject("Sound");
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
		audioSource.outputAudioMixerGroup = mixer;
		//audioSource.PlayOneShot(clip);
		audioSource.clip = clip;
		audioSource.loop = bLoop;
		audioSource.Play();

		sources.Add(audioSource);
	}

	void StopAudio(AudioClip clip)
	{
		foreach (AudioSource source in sources)
		{
			if (source.clip == clip)
			{
				source.Pause();
				return;
			}
		}
	}
}
