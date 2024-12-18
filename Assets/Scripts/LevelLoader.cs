﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public Animator transition;
    
    public void LoadNextLevel(int index)
	{
		StartCoroutine(LoadLevel(index));
	}

	public void NextLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}

	IEnumerator LoadLevel(int levelIndex)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(1f);

		SceneManager.LoadScene(levelIndex);
	}
}
