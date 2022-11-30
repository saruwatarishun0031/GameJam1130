using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魚1匹を管理するコンポーネント
/// </summary>
public class FishUnit : MonoBehaviour
{
    // 魚の大きさ 大:3 中:2 小:1
    [SerializeField] int _size;
    FishMove _fishMove;

    void Awake()
    {
        _fishMove = GetComponent<FishMove>();
    }

    void Start()
    {

    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Capture();
            Debug.Log("魚のデバッグ機能で移動を停止させました");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Escape();
            Debug.Log("魚のデバッグ機能で逃がしました");
        }
#endif
    }

    /// <summary>初期化処理</summary>
    public void Init(Transform centerPoint, Transform escapePoint)
    {
        _fishMove.SetWayPoint(centerPoint, escapePoint);
        _fishMove.StartMove();
    }

    /// <summary>
    /// 魚を吊り上げバトル状態にさせる
    /// 魚が釣り竿にヒットした時に呼ぶ
    /// </summary>
    public void Capture()
    {
        _fishMove.StopMove();
        // TODO:釣り上げ中のアニメーション
    }

    /// <summary>
    /// もう釣れない状態にして逃がす
    /// </summary>
    public void Escape()
    {
        _fishMove.EscapeMove();
    }

    /// <summary>
    /// 釣られた時に呼ばれる
    /// </summary>
    public void Caught()
    {
        Debug.Log("釣られました");
    }
}
