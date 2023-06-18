using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private string[] themes;
    void Start()
    {
        FindObjectOfType<AudioManager>().Play(themes[Random.Range(0,themes.Length)]);
        FreezeTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FreezeTime()
	{
        Time.timeScale = 0f;
	}

    public void KeepTime()
	{
        Time.timeScale = 1f;
	}
}
