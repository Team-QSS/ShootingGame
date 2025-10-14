using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    //이동 함수
    public void SetMove(Vector2 dir)
    {
        rb2D.linearVelocity = dir;
    }

}
