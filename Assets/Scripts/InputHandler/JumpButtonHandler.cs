using Player.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerMovement _playerMovement;
    public bool _isJumping = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isJumping == false)
        {
            _playerMovement.Jump();
            _isJumping = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isJumping = false;
    }
}
