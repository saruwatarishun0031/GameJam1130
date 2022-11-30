using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 魚の動きを制御するコンポーネント
/// </summary>
public class FishMove : MonoBehaviour
{
    // 魚の速度
    [SerializeField] float _speed;

    // 釣り竿の座標、動的にnullになる
    Transform _rod;
    
    // 魚が目指す地点
    // _centerPointに向けて進んで、しばらく経ったら_escapePointに向けて進む
    Vector3 _centerPoint;
    Transform _escapePoint;

    Sequence _seq;

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// 初期化、魚が目指す地点を渡す
    /// ジェネレーター側から呼ぶ想定になっている
    /// </summary>
    public void SetWayPoint(Vector3 centerPoint, Transform escapePoint)
    {
        _centerPoint = centerPoint;
        _escapePoint = escapePoint;
    }

    /// <summary>移動を開始させる</summary>
    public void StartMove()
    {
        _seq = DOTween.Sequence();
        _seq.AppendCallback(() => transform.rotation = Quaternion.FromToRotation(Vector3.up, _centerPoint - transform.position));
        _seq.Append(transform.DOMove(_centerPoint, _speed));
        _seq.AppendCallback(() => transform.rotation = Quaternion.FromToRotation(Vector3.up, _escapePoint.position - transform.position));
        _seq.Append(transform.DOMove(_escapePoint.position, _speed));
    }

    /// <summary>
    /// 竿が近くにあったら寄っていく
    /// このメソッドは釣り竿がnullじゃない場合にのみ呼ばれる
    /// </summary>
    void ApproachRod()
    {
        // 行動を中断するのでKillする
        if (_seq != null) _seq.Kill();
        
        // 釣り竿を目指す
        _seq.Append(transform.DOMove(_rod.position, _speed));
    }

    /// <summary>
    /// 現在の状態からWayPointを目指しての移動に切り替える
    /// 現在は釣り竿に他の魚がかかった場合にのみ呼ばれる想定
    /// </summary>
    void ChangeWayPointMove()
    {
        // 行動を中断するのでKillする
        if (_seq != null) _seq.Kill();

        // 釣り竿を目指す
        _seq.Append(transform.DOMove(_escapePoint.position, _speed));
    }

    /// <summary>
    /// 移動を止める
    /// 餌に食いついた時に呼ぶ想定になっている
    /// </summary>
    public void StopMove()
    {
        _seq.Kill();
    }

    /// <summary>
    /// 逃げ出すときのアニメーション
    /// 釣りバトルに魚が勝って逃げ出すときに呼ぶ
    /// </summary>
    public void EscapeMove()
    {
        // 食いついた後にこのメソッドが呼ばれるので_seqはキルされている予定だが
        // 一応ここでnullチェックをしておく、外部に依存していないので不要なら消す
        if (_seq != null) _seq.Kill();

        // TODO:逃げるときのアニメーションを作る
        //      逃げた後にコールバックを追加して何かできるようになっているので必要なら追加する
        Sequence escapeSeq = DOTween.Sequence();
        escapeSeq.Append(transform.DOScale(Vector3.zero, 0.5f));
        escapeSeq.AppendCallback(() => Debug.Log("にげました"));
    }
}
