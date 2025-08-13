using Player.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotJumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RobotMovement _robotMovement;

    public bool _isJumping = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isJumping == false)
        {
            _robotMovement.Jump();
            _isJumping = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isJumping = false;
    }
}
