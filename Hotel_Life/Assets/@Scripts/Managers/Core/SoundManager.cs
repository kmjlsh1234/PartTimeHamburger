using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
	private AudioSource[] _audioSources = new AudioSource[(int)Define.ESound.Effect];
	private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
	private GameObject _soundRoot = null;

	public void Init()
    {
		if(_soundRoot == null)
        {
			_soundRoot = GameObject.Find("@SoundRoot");
			if(_soundRoot == null)
            {
				_soundRoot = new GameObject { name = "@SoundRoot" };
				UnityEngine.Object.DontDestroyOnLoad(_soundRoot);

				string[] soundTypeNames = System.Enum.GetNames(typeof(Define.ESound));
				for(int i=0; i<soundTypeNames.Length; i++)
                {
					GameObject go = new GameObject { name = soundTypeNames[i] };
					_audioSources[i] = go.AddComponent<AudioSource>();
					go.transform.parent = _soundRoot.transform;
                }

				_audioSources[(int)Define.ESound.BGM].loop = true;
            }
        }
    }

	public void Clear()
    {
		foreach (AudioSource audioSource in _audioSources)
			audioSource.Stop();

		_audioClips.Clear();
    }

	public void Play(Define.ESound type, string key, float pitch = 1.0f)
    {
		var audioSource = _audioSources[(int)type];

		if(type == Define.ESound.BGM)
        {
			LoadAudioClip(key, (audioClip) =>
			{
				if (audioSource.isPlaying)
					audioSource.Stop();

				audioSource.clip = audioClip;
				audioSource.Play();
			});
        }
        else
        {
			LoadAudioClip(key, (audioClip) => {
				audioSource.pitch = pitch;
				audioSource.PlayOneShot(audioClip);
			});
        }
    }

	private void LoadAudioClip(string key, Action<AudioClip> callback)
    {
		AudioClip audioClip = null;
		if(_audioClips.TryGetValue(key, out audioClip))
        {
			callback?.Invoke(audioClip);
			return;
        }

		audioClip = Managers.Resource.Load<AudioClip>(key);

		if (_audioClips.ContainsKey(key) == false)
			_audioClips.Add(key, audioClip);
		callback?.Invoke(audioClip);
    }

	public void Stop(Define.ESound type)
    {
		var audioSource = _audioSources[(int)type];
		audioSource.Stop();
    }
    
}
