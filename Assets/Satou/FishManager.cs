using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ʓ��̋��S�̂��Ǘ�����
/// </summary>
public class FishManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    
    List<FishUnit> _fishList;

    // �O�t���[���̒l
    bool _prev;

    void Start()
    {
        
    }

    void Update()
    {
        //// �O�̃t���[���ŏo���Ă��Ȃ���Ԃ��A���t���[���ŏo������ԂȂ�
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
