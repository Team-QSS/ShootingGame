using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed;
    //�̵� �Լ�
    public void SetMove(Vector2 dir)
    {
        rb2D.linearVelocity = dir*speed;
    }

}
