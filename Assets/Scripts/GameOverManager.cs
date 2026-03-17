using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour 
{
	public static GameOverManager current;

	[SerializeField] private string nextLevelName;
	[SerializeField] private float displayDelay = 0.5f;
	[SerializeField] private float restartDelay = 0.5f;

	public void RestartGame()
	{
		StartCoroutine (RestartTimer ());
	}

	public void LoseGame()
	{
		CursorBehavior.current.SetIsDisabled (true);
		ChargeBarBehavior.current.SetIsDisabled (true);

		StartCoroutine (RestartTimer ());
	}

	public void WinGame()
	{
		CursorBehavior.current.SetIsDisabled (true);
		ChargeBarBehavior.current.SetIsDisabled (true);

		StartCoroutine(NextLevelTimer());
	}

	public void QuitGame()
	{
		StartCoroutine(QuitGameCoroutine());	
	}

	private void Awake()
	{
		current = this;
	}

	private IEnumerator DisplayDelayTimer()
	{
		yield return new WaitForSeconds (displayDelay);
		NewsPanelBehavior.current.SetAnimState (1);
	}

	private IEnumerator RestartTimer()
	{
		yield return new WaitForSeconds (displayDelay);
		FaderBehavior.current.SetAnimState (1);
		yield return new WaitForSeconds (restartDelay);
		SceneChanger.current.ChangeScene (SceneManager.GetActiveScene ().name);
	}

	private IEnumerator NextLevelTimer()
	{
		yield return new WaitForSeconds (displayDelay);
		FaderBehavior.current.SetAnimState (1);
		yield return new WaitForSeconds (restartDelay);
		SceneChanger.current.ChangeScene (nextLevelName);
	}

	private IEnumerator QuitGameCoroutine()
	{
		yield return new WaitForSeconds (displayDelay);
		FaderBehavior.current.SetAnimState (1);
		yield return new WaitForSeconds (restartDelay);
		Application.Quit();
	}
}
