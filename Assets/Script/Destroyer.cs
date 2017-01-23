using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Destroyer : MonoBehaviour
{
	public AudioClip explosion;
	private AudioSource source;
	void Start()
	{
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (explosion, 1);
	}

	void DestroyGameObject()
	{
		Destroy(gameObject);
	}
}
