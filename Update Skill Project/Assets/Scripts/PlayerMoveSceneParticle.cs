using UnityEngine;

public class PlayerMoveSceneParticle : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float inputHor = Input.GetAxisRaw("Horizontal");
        float inputVer = Input.GetAxisRaw("Vertical");
        if (inputHor > 0f || inputVer >0f)
        {
            speed = Mathf.Abs(speed);
        }
        else if (inputHor < 0f || inputVer<0f )
        {
            speed = -Mathf.Abs(speed);
        }
        if (inputHor != 0f)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (inputVer != 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }
}
