using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector2 _lastCheckpointPosition = Vector2.zero;//������� ���������� ���������
    //��� ��� ��� ����������� �� ����� ������������ �� ���������� ����
    
    public Vector2 LastCheckpointPosition => _lastCheckpointPosition;

    private void Start()
    {
        if (_lastCheckpointPosition != Vector2.zero)
        {
            transform.position = _lastCheckpointPosition;
            //����� ��������������� ��������� ������ ���� �� "������" ���� �� ���� ��������
        }
    }
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Checkpoint"))
        {
            _lastCheckpointPosition = _collision.transform.position;
            //���������� ������� ����� ���������� � ����������
        }
    }
}

