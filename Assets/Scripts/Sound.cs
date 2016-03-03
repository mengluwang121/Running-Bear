using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	public AudioClip m_music;
	protected AudioSource m_audio;
	// Use this for initialization
	void Start () {
		m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {
	if (!m_audio.isPlaying) {
			m_audio.clip=m_music;
			m_audio.Play();
		}
	}
}
