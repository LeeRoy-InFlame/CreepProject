using Player.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerShoot _playerShoot;
    private bool _pressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_pressed == false)
        {
            _playerShoot.Shooting();
            _pressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }
}
