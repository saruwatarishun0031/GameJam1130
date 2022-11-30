using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魚を湧かせるためのジェネレータ
/// ステージの複数個所に配置する
/// </summary>
public class Generator : MonoBehaviour
{
    /// <summary>ジェネレーターの状態</summary>
    public bool IsActive = false;

    IEnumerator Start()
    {
        // 外部からオンにするまでジェネレータを起動させない
        yield return new WaitUntil(() => IsActive);

        while (IsActive)
        {
            Debug.Log("魚を生成");
            yield return 0.1f;
        }
        Debug.Log("ジェネレータを停止します");
    }

    void Update()
    {
#if UNITY_EDITOR
        // デバッグ用、状態を切り替える
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsActive = !IsActive;
            Debug.Log("ジェネレータのデバッグ機能で状態を切り替えました:" + IsActive);
        }
#endif
    }
}
