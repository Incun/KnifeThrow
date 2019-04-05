using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Transform knifeIconParentTF, knifeMakePosTF;
	public GameObject knifeIconPrefebObj, knifeObj;
	public float makeDelay = 1f;
	public int knifeTotalCount = 5;
	public Text scoreText;
	public bool isGameOver = false;
	public GameObject gameoverObj;

	private List<Image> knifeIconList = new List<Image>();
	private int score = 0;

	public int Score
	{
		get
		{ 
			return score; 
		}
		set
		{
			score = value;
			scoreText.text = score.ToString();
		}
	}

	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}


	void Awake()
	{
		if(instance)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
		
	}

	void Start()
	{
		for(int i = 0 ; i < knifeTotalCount ; i++)
		{
			knifeIconList.Add
			(
				Instantiate(knifeIconPrefebObj, knifeIconParentTF).GetComponent<Image>()
			);
		}
	}

	void Update()
	{
		Gameover();
	}

	public void Throw()
	{
		

		if(Knife.instance == null)
		{
			return;
		}
		Knife.instance.Throw();
		if(knifeIconList.Count > 0)
		{
			knifeIconList[0].color = Color.black;
			knifeIconList.RemoveAt(0);
		}
		StartCoroutine (MakeKnifeCoroutine(makeDelay));
	}

	public void Gameover()
	{
		if(isGameOver == true)
		{
			gameoverObj.SetActive(true);
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator MakeKnifeCoroutine(float delay)
	{
		yield return new WaitForSeconds(delay);
		if(isGameOver)
		{
			Debug.Log("Game Over!");
		}
		else
		{
			Instantiate(knifeObj).transform.position = knifeMakePosTF.position;
		}
	}
	
}

