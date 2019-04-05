using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
	public float throwpower = 400f;
	private Rigidbody2D rb2d;
	public const string appleTag = "Apple";
	public const string knifeTag = "Knife";
	private bool isOver = false;
	public float dis;

	public static Knife instance;

	public virtual void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		instance = this;
	}

	public virtual void Throw()
	{
		if(GameManager.Instance.isGameOver == false)
		{
			instance = null;
			rb2d.AddForce(Vector3.up * throwpower);
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		if(isOver)
		{
			return;
		}
		isOver = true;
		if(col.transform.tag.Equals(appleTag))
		{
			Destroy(rb2d);
			transform.SetParent(col.transform);
			GameManager.Instance.Score++;
			Apple.instance.Shake();
		}
		else
		{
			dis = Random.Range(1, 2);
			GameManager.Instance.isGameOver = true;
			rb2d.gravityScale = 8f;
			if(dis == 1)
			{
				rb2d.AddForce(Vector3.right * 300f);
				rb2d.AddForce(Vector3.down * 400f);
			}
			else if(dis == 2)
			{
				rb2d.AddForce(Vector3.left * 300f);
				rb2d.AddForce(Vector3.down * 400f);
			}
			rb2d.AddTorque(1000f);
		}
	}
}
