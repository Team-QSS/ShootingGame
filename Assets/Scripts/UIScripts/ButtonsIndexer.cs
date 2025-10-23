using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsIndexer : MonoBehaviour
{
    public GameObject[] buttons;
    [SerializeField] private int startIndex;

    private void Start()
    {
        SelectTarget();
    }

    public void SelectTarget()
    {
        startIndex %= buttons.Length;
        var pointerEventData = new PointerEventData(EventSystem.current);
        buttons[startIndex].GetComponent<IPointerEnterHandler>().OnPointerEnter(pointerEventData);
    }

    public void ExitTarget()
    {
        startIndex %= buttons.Length;
        var pointerEventData = new PointerEventData(EventSystem.current);
        buttons[startIndex].GetComponent<IPointerExitHandler>().OnPointerExit(pointerEventData);
    }

    public void OnMove(int direction)
    {
        ExitTarget();
        startIndex += direction;
        if (startIndex < 0)
        {
            startIndex = buttons.Length - 1;
        }
        SelectTarget();
    }

    public void OnSet(int index)
    {
        ExitTarget();
        startIndex = index;
    }

}
