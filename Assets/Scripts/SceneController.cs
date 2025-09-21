using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneController : MonoBehaviour
{
    private const int MAIN_MENU_SCENE_INDEX = 0;
    private const int GAME_SCENE_INDEX = 1;

    public void OpenMainScene()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX);
    }

    public void OpenGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE_INDEX, LoadSceneMode.Additive);
    }

    public void UnloadGameScene()
    {
        if (SceneManager.sceneCount > 1)
        {
            SceneManager.UnloadSceneAsync(GAME_SCENE_INDEX);
        }
    }
}
