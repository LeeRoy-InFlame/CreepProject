using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Player.Inputs;

public class SimpleJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _joystickBG;
    [SerializeField] private RectTransform _joystickHandle;
    [SerializeField] private float _handleRange;
    [SerializeField] private TakeControl _takeControl;

    private Vector2 _inputVector;

    private void Start()
    {
        _inputVector = Vector2.zero;
        _joystickHandle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_takeControl != null && _takeControl.ControlOff == false)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBG, eventData.position,
                eventData.pressEventCamera, out pos);
            _inputVector = new Vector2(pos.x / _handleRange, 0);
            _inputVector = Vector2.ClampMagnitude(_inputVector, 1.0f);

            _joystickHandle.anchoredPosition = _inputVector * _handleRange;
        } 
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetInput();
    }

    public void ResetInput()
    {
        _inputVector = Vector2.zero;
        _joystickHandle.anchoredPosition = Vector2.zero;
    }

    public float Horizontal() => _inputVector.x;
    public Vector2 Direction() => _inputVector;
}
