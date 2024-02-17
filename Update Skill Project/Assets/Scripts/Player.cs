using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler<OnInteractionEventArgs> OnInteraction;
    public class OnInteractionEventArgs : EventArgs
    {
        public Transform objectSelect {  get; set; }
    }
    public static Player Instance {  get; private set; }
    [SerializeField] private float speed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask layerMask;
    private Rigidbody2D rb;
    private Transform objectSelect;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnPressKeyE += GameInput_OnPressKeyE;
    }
    private void Test()
    {
        if (objectSelect == null)
        {
            if (transform.GetComponentInChildren<Iteam>() != null)
            {
                Iteam _iteam = transform.GetComponentInChildren<Iteam>();
                _iteam.SetParentIteam(null);
                _iteam.GetComponent<CircleCollider2D>().enabled = true;
            }
            else
            {

            }
        }
        else
        {
            if (transform.GetComponentInChildren<Iteam>() == null)
            {
                if (objectSelect.gameObject.layer == LayerMask.NameToLayer("Iteam"))
                {
                    objectSelect.GetComponent<Iteam>().SetParentIteam(transform);
                }
                else
                {

                }
            }
            else
            {
                Iteam _iteam = transform.GetComponentInChildren<Iteam>();
                _iteam.SetParentIteam(null);
                _iteam.GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }
    private void GameInput_OnPressKeyE(object sender, EventArgs e)
    {
        //Test();
        if (objectSelect == null)
        {
            if (transform.GetComponentInChildren<Iteam>() != null)
            {
                Iteam _iteam = transform.GetComponentInChildren<Iteam>();
                _iteam.SetParentIteam(null);
            }
            else
            {

            }
        }
        else
        {
            if (transform.GetComponentInChildren<Iteam>() == null)
            {
                if (objectSelect.gameObject.layer == LayerMask.NameToLayer("Iteam"))
                {
                    objectSelect.GetComponent<Iteam>().SetParentIteam(transform);
                }
                else if (objectSelect.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                {
                    if (objectSelect.GetComponentInChildren<Iteam>() != null)
                    {
                        Iteam _iteam = objectSelect.GetComponentInChildren<Iteam>();
                        _iteam.SetParentIteam(transform);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            {
                Iteam _iteam = transform.GetComponentInChildren<Iteam>();
                if (objectSelect.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                {
                    _iteam.SetParentIteam(objectSelect);
                }
                else
                {
                    _iteam.SetParentIteam(null);
                }
            }
        }
    }

    private void Update()
    {
        HandlerMovement();
        HandlerInteraction();
    }
    private void HandlerMovement()
    {
        Vector2 moveDir = gameInput.GetMoveDirec();
        if (moveDir != Vector2.zero)
        {
            if (rb.velocity.x != 0) transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1f, 1f);
            rb.velocity = moveDir * speed;
        }  
    }
    private void HandlerInteraction()
    {
        float radius = .6f;
        Collider2D[] colliderArr = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        float minDis = Mathf.Infinity;
        Transform tranformSelect = null;
        foreach (Collider2D collider in colliderArr)
        {
            float curDis = Vector3.Distance(transform.position, collider.transform.position);
            if (curDis < minDis)
            {
                minDis = curDis;
                tranformSelect = collider.transform;
            }
        }
        SetObjectSelect(tranformSelect);
    }
    private void SetObjectSelect(Transform tranformSelect)
    {
        objectSelect = tranformSelect;
        OnInteraction?.Invoke(this,new OnInteractionEventArgs { objectSelect = objectSelect });
    }
}
