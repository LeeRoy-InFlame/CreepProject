using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesSwitcher : MonoBehaviour
{
    [SerializeField] private int _levelNumber;

    public int LevelNumber => _levelNumber;

    public void LoadThisScene()
    {
        SceneManager.LoadScene(_levelNumber);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
