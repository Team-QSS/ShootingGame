using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;

    public void SetMove(Vector2 dir)
    {
        rb2D.linearVelocity = dir;
    }

}
