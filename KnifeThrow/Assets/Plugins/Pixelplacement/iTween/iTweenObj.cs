using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenObj : MonoBehaviour
{

	void Start ()
	{
		iTween.ScaleBy(gameObject, iTween.Hash("x", 0.9, "y", 0.9, "easeType", "easeInCirc", "loopType", "pingPong", "Time", 0.5));
	}
}
