using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.SingletonPatternSystem;

public class GameLaunch : MonoSingleton<GameLaunch>
{
    protected override void Awake()
    {
        base.Awake();
        //初始化游戏框架
        gameObject.AddComponent<XLuaManager>();
    }

    private async void Start()
    {
        await GameStart();
        //启动Lua虚拟机
        XLuaManager.Instance.EnterGame();
    }

    private async UniTask Updated()
    {
        //更新资源
        await UniTask.Yield();
        Debug.Log("Updated");
    }

    private async UniTask GameStart()
    {
        await Updated();
        Debug.Log("GameStart");
    }
}