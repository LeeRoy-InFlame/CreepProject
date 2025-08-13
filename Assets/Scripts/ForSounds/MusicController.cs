using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //придумал такую систему запуска музыки при перезагрузки уровня на чекпоинте иначе музыка не воспроизводилась
    [SerializeField] private SoundAssetMenu _musicCollection;
    [SerializeField] private Checkpoint _checkpoint;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _listener;
    

    private void Awake()
    {
        _audioSource.clip = _musicCollection._currentSound[SceneManager.GetActiveScene().buildIndex];
        _audioSource.Play();
    }

    public void ListenerOn()
    {
        _listener.GetComponent<AudioListener>().enabled = true;
    }

    public void MainMenuMusic()
    {
        _audioSource.clip = _musicCollection._currentSound[0];
        _audioSource.Play();
    }

    public void BeginCutsceneMusic()
    {
        _audioSource.clip = _musicCollection._currentSound[1];
        _audioSource.Play();
    }

    public void LevelMusic()
    {
        _audioSource.clip = _musicCollection._currentSound[2];
        _audioSource.Play();
    }

    public void RunRobotMusic()
    {
        _audioSource.clip = _musicCollection._currentSound[4];
        _audioSource.Play();
    }

    public void CreepMusic()
    {
        _audioSource.clip = _musicCollection._currentSound[5];
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void NullMusic()
    {
        _audioSource.clip = null;
    }
}
