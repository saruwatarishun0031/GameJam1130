using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魚を湧かせるためのジェネレータ
/// ステージの複数個所に配置する
/// </summary>
public class Generator : MonoBehaviour
{
    //[SerializeField] FishManager _fishManager;
    /// <summary>生成する魚のプレハブ</summary>
    [SerializeField] GameObject[] _fishPrefabs;
    /// <summary>全ての魚が目指す画面中央のポイント</summary>
    [SerializeField] Transform _centerPoint;
    /// <summary>魚ごとにランダムな逃走ポイントに向かうようにする</summary>
    [SerializeField] Transform[] _escapePoints;

    /// <summary>ジェネレーターの状態</summary>
    public bool IsActive = false;

    IEnumerator Start()
    {
        // 外部からオンにするまでジェネレータを起動させない
        yield return new WaitUntil(() => IsActive);

        while (IsActive)
        {
            int fr = Random.Range(0, _fishPrefabs.Length);
            int pr = Random.Range(0, _escapePoints.Length);

            // TODO:全部の魚が共通して呼ぶものなのでstaticなクラスを別途つくり、そっちにwayPointを持たせ
            //      魚側が自分でWayPointを設定するようにする
            // 魚を生成して初期化処理を呼ぶ。
            GameObject go = Instantiate(_fishPrefabs[fr], transform.position, Quaternion.identity);
            FishUnit unit = go.GetComponent<FishUnit>();
            unit.Init(_centerPoint.position, _escapePoints[pr]);
            
            // 管理させる
            //_fishManager.AddFishList(unit);
            
            yield return new WaitForSeconds(3.0f);
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
