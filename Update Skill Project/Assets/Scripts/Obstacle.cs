using UnityEngine;

public class Obstacle : MonoBehaviour, IInteraction
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Player.Instance.OnInteraction += Instance_OnInteraction;
    }

    private void Instance_OnInteraction(object sender, Player.OnInteractionEventArgs e)
    {
        if (e.objectSelect == transform)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Interac()
    {
    }

    public void Show()
    {
        spriteRenderer.color = Color.black;
    }

    public void Hide()
    {
        spriteRenderer.color = Color.white;
    }
}
