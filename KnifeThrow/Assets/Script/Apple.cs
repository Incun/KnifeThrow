using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour 
{
	public static Apple instance;
	public float shakepower = 1f;
	public SpriteRenderer sr;

	void Awake()
	{
		instance = this;
		sr = GetComponent<SpriteRenderer>();
	}

	public void Shake()
	{
		StartCoroutine(ShakeCoroutine());
		StartCoroutine(WhiteEffectCorouTine());
	}

	IEnumerator ShakeCoroutine ()
	{
		float t = 1f;
		Vector2 origenV = transform.position;
		while (t > 0f)
		{
			t -= 0.15f;
			transform.position = origenV + Random.insideUnitCircle * shakepower * t;

			yield return null;
		}
		transform.position = origenV;
	}

	IEnumerator WhiteEffectCorouTine()
	{
		float t = 0f;
		while(t < 1f)
		{
			t += 0.15f;
			sr.material.SetFloat("_FlashAmount", t); 
			yield return null;
		}

		while(t > 0f)
		{
			t -= 0.15f;
			sr.material.SetFloat("_FlashAmount", t); 
			yield return null;
		}

		sr.material.SetFloat("_FlashAmount", 0f);
	}
}
