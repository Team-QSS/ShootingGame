using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractorConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private StartButton startButton;
    [SerializeField] private OptionsButton optionsButton;
    [SerializeField] private QuitButton quitButton;

    [SerializeField] private SlidingPannels titlesP;
    [SerializeField] private SlidingPannels buttonsP;
    [SerializeField] private CircleMultiplyer blackHole;
    private void Start()
    {
        Connect();
    }
    public void Connect()
    {
        startButton.onStartLate += blackHole.StartFade;
        startButton.onStartEarly+=titlesP.Disappear;
        startButton.onStartEarly+=buttonsP.Disappear;
        quitButton.onQuitLate+=blackHole.StartFade;
        quitButton.onQuitEarly+=titlesP.Disappear;
        quitButton.onQuitEarly+=buttonsP.Disappear;
    }

    public void Disconnect()
    {
        startButton.onStartLate -= blackHole.StartFade;
        startButton.onStartEarly-=titlesP.Disappear;
        startButton.onStartEarly-=buttonsP.Disappear;
        quitButton.onQuitLate-=blackHole.StartFade;
        quitButton.onQuitEarly-=titlesP.Disappear;
        quitButton.onQuitEarly-=buttonsP.Disappear;
    }
}
