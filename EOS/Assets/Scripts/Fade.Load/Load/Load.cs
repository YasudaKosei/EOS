using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{

	private AsyncOperation async;

	public Text loadingText;
	public Slider loadingBar;

	public static int SL = 0;

	[SerializeField] Fade fade;

	void Start()
	{
		loadingText.text = "0%".ToString();

		loadingBar.value = 0;

		fade.FadeOut(1f, () => StartCoroutine(SceneLoad()));
	}

	private IEnumerator SceneLoad()
	{
		if (SL == 0)
		{
			async = SceneManager.LoadSceneAsync("Title");
		}

		else if (SL == 1)
		{
			async = SceneManager.LoadSceneAsync("StageSelect");
		}

		else if (SL == 2)
		{
			async = SceneManager.LoadSceneAsync("Stage01");
		}

		else if (SL == 3)
		{
			async = SceneManager.LoadSceneAsync("Stage02");
		}

		else if (SL == 4)
		{
			async = SceneManager.LoadSceneAsync("Stage03");
		}

		else if (SL == 5)
		{
			async = SceneManager.LoadSceneAsync("Stage04");
		}

		else if (SL == 6)
		{
			async = SceneManager.LoadSceneAsync("Stage05");
		}

		async.allowSceneActivation = false;

		while (async.progress < 0.9f)
		{
			loadingText.text = (async.progress * 100).ToString("f0") + "%";

			loadingBar.value = async.progress;

			yield return new WaitForSeconds(0);
		}

		loadingText.text = (async.progress * 100).ToString("f0") + "%";


		loadingBar.value = async.progress;


		yield return new WaitForSeconds(0.1f);


		loadingText.text = "100%";


		loadingBar.value = 1;

		fade.FadeIn(1f, () => async.allowSceneActivation = true);
	}
}