using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    #region Singleton
    private static UIButtonHandler instance;
    public static UIButtonHandler Instance
    {
        get 
        {
            if (!FindObjectOfType<UIButtonHandler>())
            {
                GameObject newGameObject = new GameObject();
                newGameObject.AddComponent<UIButtonHandler>();
                instance = newGameObject.GetComponent<UIButtonHandler>();
            }
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
