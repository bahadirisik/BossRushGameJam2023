using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	Resolution[] resolutions;

	public Dropdown resolutionDropdown;
	[SerializeField] private LevelLoader levelLoader;

	private void Start()
	{
		FindObjectOfType<AudioManager>().Play("Theme4");

		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}
	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume",volume / 2.5f);
	}

	public void PlayButton()
	{
		GunSelect.weaponTags.Clear();
		levelLoader.LoadNextLevel(1);
	}

	public void QuitButton()
	{
		Application.Quit();
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
	}
}
