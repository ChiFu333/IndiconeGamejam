using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
public static class MyTweens
{
    public static async UniTask DOSScaleSaveBounce(this Transform source, Vector3 resultPos, float time)
    {
        await source.DOScale(resultPos, time).SetEase(Ease.InOutBack)
        .OnUpdate(() =>
        {
            var s = source.localScale;
            if (s.x < 0 || s.y < 0 || s.z < 0)
            {
                source.localScale = Vector3.zero;
            }
        }).AsyncWaitForCompletion().AsUniTask();
    }
}
