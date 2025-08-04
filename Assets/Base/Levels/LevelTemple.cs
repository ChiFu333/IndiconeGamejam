using UnityEngine;
using Cysharp.Threading.Tasks;

public class LevelTemple : MonoBehaviour
{
    private bool trigger = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async UniTaskVoid Start()
    {
    }

    public async UniTask WaitTrigger()
    {
        trigger = false;
        await UniTask.WaitUntil(() => trigger);
    }

    public void TriggerBool()
    {
        trigger = true;
    }

    private void NextLevel()
    {
        G.Main.NextLevel();
    }
}
