using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        /*ShapeFactory shape_ = FindObjectOfType<ShapeFactory>();
        Transform square_ = shape_.CreateShape(ShapeFactory.ShapeType.Square);
        square_.GetComponent<Square>().ChangeColor(Color.red);
        IShape getSquare = shape_.GetShape(ShapeFactory.ShapeType.Square, Color.green);*/
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ObjectPooler.Instance.GetTransform("Circle", transform.position, transform.rotation);
        }
    }
}
