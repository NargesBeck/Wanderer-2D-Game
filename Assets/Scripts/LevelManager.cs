using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<LevelManager>();
            return instance;
        }
    }

    private void Awake()
    {
        Player.Instance.OnLevelWon = () => ResetLevel(true);
        Player.Instance.OnLevelLost = () => ResetLevel(false);
    }
    private void ResetLevel(bool playerWon)
    {
        DisplayUIAtTheEndOfLevel(playerWon);
        StartCoroutine(ReloadSceneWithDelay());
    }

    private void DisplayUIAtTheEndOfLevel(bool playerWon)
    {
        UIManager.Instance.LevelEnded(playerWon);
    }

    private IEnumerator ReloadSceneWithDelay()
    {
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
