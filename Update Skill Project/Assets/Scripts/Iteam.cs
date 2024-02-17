using UnityEngine;

public class Iteam : MonoBehaviour, IInteraction
{
    private SpriteRenderer spriteRenderer;
    private Transform _parent;
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
        spriteRenderer.color = Color.yellow;
    }
    public void SetParentIteam(Transform parent)
    {
        _parent = parent;
        if (_parent == null)
        {
            transform.GetComponent<CircleCollider2D>().enabled = true;
            transform.parent = null;
            transform.position = new Vector3(transform.position.x,-3.79f,transform.position.z);
        }
        else if (_parent.transform.GetComponentInChildren<Iteam>() == null) 
        {
            transform.position = _parent.GetChild(1).position;
            transform.parent = _parent;
            transform.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {

        }
    }
    public Transform GetParentIteam()
    {
        return _parent;
    }
}
