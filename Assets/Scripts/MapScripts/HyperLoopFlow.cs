using UnityEngine;

public class HyperLoopFlow : MapFlow
{
    public override void Initialize()
    {
        base.Initialize();
        eventTable[CheckIndex(5)] += OnMoveTutorial;
        eventTable[CheckIndex(7)] += OnSkillTutorial;
        eventTable[CheckIndex(8)] += EndTutorial;
        eventTable[CheckIndex(11)] += OnWaveStart;

    }
    public void OnMoveTutorial()
    {
        EventManager.Instance.Invoke(EventKey.ChangeTextOnDescriptionPanel,"방향키를 눌러 움직이세요");
        EventManager.Instance.Invoke(EventKey.ShowDescriptionPanel,true);
        EventManager.Instance.Invoke(EventKey.ActiveImageOnDescriptionPanel,0);
        GameTimeManager.Instance.StopClock();
    }
    public void OnSkillTutorial()
    {
        EventManager.Instance.Invoke(EventKey.ChangeTextOnDescriptionPanel,"대각선 위 버튼을 눌러\n특수능력을 사용하세요");
        EventManager.Instance.Invoke(EventKey.ShowDescriptionPanel,true);
        EventManager.Instance.Invoke(EventKey.ActiveImageOnDescriptionPanel,1);
        GameTimeManager.Instance.StopClock();
    }

    public void EndTutorial()
    {
        EventManager.Instance.Invoke(EventKey.ChangeTextOnDescriptionPanel,"이제 시뮬레이션이 모두 끝났으니\n하이퍼루프를 타고 탈출해 봅시다!");
        EventManager.Instance.Invoke(EventKey.ShowDescriptionPanel,true);
        EventManager.Instance.Invoke(EventKey.ActiveImageOnDescriptionPanel,-1);
    }

    public void OnWaveStart()
    {
        EventManager.Instance.Invoke(EventKey.ShowWavePanel,"제 1 웨이브");
    }

}
