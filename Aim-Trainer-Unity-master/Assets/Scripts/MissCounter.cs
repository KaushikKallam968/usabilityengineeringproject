using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
	[SerializeField] TMP_Text text;
	public static int Misses { get; private set; }

    private void Start()
    {
		Misses = 0; //reset counter on level start
    }

    void OnEnable()
	{
		TargetShooter.OnTargetMissed += OnTargetMissed;
	}

	void OnDisable()
	{
		TargetShooter.OnTargetMissed -= OnTargetMissed;
	}

	void OnTargetMissed()
	{
		Misses++;
		text.text = $"Misses: {Misses}";
	}
}
