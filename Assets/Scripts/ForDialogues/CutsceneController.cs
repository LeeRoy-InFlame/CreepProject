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
    private bool _isSkipCutscene;

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

        if (_isSkipCutscene == true && _cutscene.time != 0f)
        {
            SkipCutscene();
            _isSkipCutscene = false;
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
        _cutscene.time = _cutscene.duration;
        _cutscene.Evaluate();
        _isSkipCutscene = false;
    }

    public void OnSkipButtonDown()
    {
        _isSkipCutscene = true;
    }
}
