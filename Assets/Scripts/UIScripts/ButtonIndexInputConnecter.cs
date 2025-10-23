using UnityEngine;

public class ButtonIndexInputConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] ButtonsIndexer buttonsIndexer;
    [SerializeField] ButtonInputter buttonInputter;
    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        foreach (var o in buttonsIndexer.buttons)
        {
            o.GetComponent<ButtonUI>().onHover += buttonsIndexer.OnSet;
        }
        buttonInputter.onMove+=buttonsIndexer.OnMove;
    }

    public void Disconnect()
    {
        foreach (var o in buttonsIndexer.buttons)
        {
            o.GetComponent<ButtonUI>().onHover -= buttonsIndexer.OnSet;
        }
        buttonInputter.onMove-=buttonsIndexer.OnMove;
    }
}
