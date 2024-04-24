using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField] TMP_Text text;
	public static int Score { get; private set; }

	private void Start()
	{
		Score = 0; //reset counter on level start
	}

	void OnEnable()
	{
		Target.OnTargetHit += OnTargetHit;
	}

	void OnDisable()
	{
		Target.OnTargetHit -= OnTargetHit;
	}

	void OnTargetHit()
	{
		Score++;
		text.text = $"Score: {Score}";
	}
}
