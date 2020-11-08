using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : GameBehaviour
{
	[SerializeField] private AudioSource AS_Ambient;
	[SerializeField] private AudioSource AS_Music;
	public AudioClip attackPlayer;
	public AudioMixerGroup mixer;

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
		eHeal,
		eUpgradeStarted,
		eUpgradeDone,
		eUpgradeFailed,
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
	}

	public void PlaySound(ESound sound)
	{
		if (!bPlay)
			return;

		PlayAudio(attackPlayer);
		switch (sound)
		{
			case ESound.eCollect:
				PlayAudio(attackPlayer);
				break;
			default:
				break;
		}
	}

	void PlayAudio(AudioClip clip)
	{
		GameObject soundGameObject = new GameObject("Sound");
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
		audioSource.outputAudioMixerGroup = mixer;
		audioSource.PlayOneShot(attackPlayer);
	}
}
