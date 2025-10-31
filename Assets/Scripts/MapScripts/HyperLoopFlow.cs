using UnityEngine;

public class HyperLoopFlow : MapFlow
{
    private EventManager _eventManager;
    private GameTimeManager _gameTime;

    public override void Initialize()
    {
        _eventManager = EventManager.Instance;
        _gameTime = GameTimeManager.Instance;

        base.Initialize();

        eventTable[CheckIndex(5)] += OnMoveTutorial;
        eventTable[CheckIndex(7)] += OnSkillTutorial;
        eventTable[CheckIndex(8)] += EndTutorial;
        eventTable[CheckIndex(11)] += OnWaveStart;
    }

    public void OnMoveTutorial()
    {
        _eventManager.Invoke(EventKey.ChangeKeyBindEvents,PlayerInputType.Move);
        _eventManager.Invoke(EventKey.ChangeTextOnDescriptionPanel, "방향키를 눌러 움직이세요");
        _eventManager.Invoke(EventKey.ShowDescriptionPanel, true);
        _eventManager.Invoke(EventKey.ActiveImageOnDescriptionPanel, 0);

        _gameTime.SetGlobalTime(0.1f);
        _gameTime.StopClock();
    }

    public void OnSkillTutorial()
    {
        _eventManager.Invoke(EventKey.ChangeKeyBindEvents,PlayerInputType.Ultimate);
        _eventManager.Invoke(EventKey.ChangeTextOnDescriptionPanel, "대각선 위 버튼을 눌러\n특수능력을 사용하세요");
        _eventManager.Invoke(EventKey.ShowDescriptionPanel, true);
        _eventManager.Invoke(EventKey.ActiveImageOnDescriptionPanel, 1);

        _gameTime.SetGlobalTime(0.1f);
        _gameTime.StopClock();
    }

    public void EndTutorial()
    {
        _eventManager.Invoke(EventKey.ChangeKeyBindEvents,PlayerInputType.Settings);
        _eventManager.Invoke(EventKey.ChangeTextOnDescriptionPanel, "이제 시뮬레이션이 모두 끝났으니\n하이퍼루프를 타고 탈출해 봅시다!");
        _eventManager.Invoke(EventKey.ShowDescriptionPanel, true);
        _eventManager.Invoke(EventKey.ActiveImageOnDescriptionPanel, -1);

        _gameTime.SetGlobalTime(0.1f);
        _gameTime.StopClock();
    }

    public void OnWaveStart()
    {
        _eventManager.Invoke(EventKey.ShowWavePanel, "제 1 웨이브");
    }
}