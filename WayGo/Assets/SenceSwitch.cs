using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public float delayInSeconds = 0.2f; // Устанавливаем задержку в секундах

    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadSceneWithDelay(sceneID));
    }

    IEnumerator LoadSceneWithDelay(int sceneID)
    {
        yield return new WaitForSeconds(delayInSeconds); // Ждем указанное количество секунд

        SceneManager.LoadScene(sceneID); // Загружаем сцену после задержки
    }
}