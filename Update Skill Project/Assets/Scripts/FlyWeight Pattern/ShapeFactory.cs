using System;
using System.Collections.Generic;
using UnityEngine;

public class ShapeFactory : MonoBehaviour
{
    [SerializeField] private Transform prefabSquare;
    [SerializeField] private Transform prefabCircle;
    private Dictionary<string,IShape> _shapes = new Dictionary<string, IShape> ();
    private IShape _shape;
    private Transform pref;
    public enum ShapeType
    {
        Square,
        Circle
    }
    public Transform CreateShape(ShapeType type)
    {
        switch (type)
        {
            case ShapeType.Square:
                pref = Instantiate(prefabSquare);
                break;
            case ShapeType.Circle:
                pref = Instantiate (prefabCircle);
                break;
            default:
                pref = null;
                break;
        }
        return pref;
    }
    public IShape GetShape(ShapeType type,Color _color)
    {
        switch (type)
        {
            case ShapeType.Square:
                string name = Enum.GetName(typeof(ShapeType),type);
                if (!_shapes.ContainsKey(name))
                {
                    _shapes[name] = new Square();
                }
                _shape = _shapes[name];
                break;
            case ShapeType.Circle:
                string name_ = Enum.GetName(typeof(ShapeType), type);
                if (!_shapes.ContainsKey(name_))
                {
                    _shapes[name_] = new Circle();
                }
                _shape = _shapes[name_];
                break;
            default:
                _shape = null;
                break;
        }
        return _shape;
    }
}
