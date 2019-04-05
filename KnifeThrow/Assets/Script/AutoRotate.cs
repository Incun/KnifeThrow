using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
	public float rotatespeed = 1f;
	void FixedUpdate()
	{
		transform.Rotate(Vector3.forward * rotatespeed);
	}
}
