using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面内の魚全体を管理する
/// </summary>
public class FishManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    
    List<FishUnit> _fishList;

    // 前フレームの値
    bool _prev;

    void Start()
    {
        
    }

    void Update()
    {
        //// 前のフレームで出していない状態かつ、今フレームで出した状態なら
        //if (_playerController.Battru && _prev !=_playerController.Battru)
        //{
        //    _fishList.ForEach()
        //}
    }

    public void AddFishList(FishUnit unit)
    {
        _fishList.Add(unit);
    }
}
