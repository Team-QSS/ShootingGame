using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    //�̵� �Լ�
    public void SetMove(Vector2 dir)
    {
        rb2D.linearVelocity = dir;
    }

}
