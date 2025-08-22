using UnityEngine;
using UnityEngine.Playables;
using Player.Inputs;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private TakeControl _takeControl;
    [SerializeField] private PlayableAsset[] _playables;
    [SerializeField] private PlayableDirector _cutscene;
    [SerializeField] private GameObject _buttonSkipCutscene;
    private int _numberPlayable = 0;

    private void Update()
    {
        if (_cutscene.time != 0)
        {
            _buttonSkipCutscene.SetActive(true);
        }
        else
        {
            _buttonSkipCutscene.SetActive(false);
        }
    }

    public void NextCutscene()
    {
        if (_numberPlayable <= _playables.Length)
        {
            _numberPlayable ++;
        }

        else if(_numberPlayable == _playables.Length)
        {
            gameObject.SetActive(false);
        }
    }

    public void ReturnControl()
    {
        if (_takeControl != null)
        {
            _takeControl.ControlOff = false;
        }
    }

    public void PlayCutscene()
    {
        if (_numberPlayable < _playables.Length)
        {
            _cutscene.playableAsset = _playables[_numberPlayable];
            _cutscene.time = 0f;
            _cutscene.Play();
        }
    }

    public void SkipCutscene()
    {
        if (_cutscene.state == PlayState.Playing) // проверяем, что катсцена реально идёт
        {
            SkipCutscene();
        }
    }

    public void OnSkipButtonDown()
    {
        _cutscene.time = _cutscene.duration;
        _cutscene.Evaluate(); ;
    }
}
