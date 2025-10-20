using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarPart : MonoBehaviour, IPoolingObject
{
    [SerializeField] Image image;
    public void OnBirth()
    {
        
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }

    public void OnDeathInit()
    {
        
    }
}
