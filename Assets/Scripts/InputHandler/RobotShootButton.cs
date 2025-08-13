using Player.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RobotShoots _robotShoots;
    private bool _pressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_pressed == false)
        {
            _robotShoots.ShotHandler();
            _pressed = true;
        } 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }
}
