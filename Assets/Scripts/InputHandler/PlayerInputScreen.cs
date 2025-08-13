using UnityEngine;

public class PlayerInputScreen : MonoBehaviour
{
    [SerializeField] private SimpleJoystick _simpleJoystick;
    [SerializeField] private float _moveSpeed;
    public Vector2 Move; 

    private void Update()
    {
        Vector2 input = _simpleJoystick.Direction();
        Move = new Vector2(input.x, 0);
        transform.Translate(Move *  _moveSpeed * Time.deltaTime);
    }
}
