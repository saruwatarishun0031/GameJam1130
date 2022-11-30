using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��1�C���Ǘ�����R���|�[�l���g
/// </summary>
public class FishUnit : MonoBehaviour
{
    // ���̑傫�� ��:3 ��:2 ��:1
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
            Debug.Log("���̃f�o�b�O�@�\�ňړ����~�����܂���");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Escape();
            Debug.Log("���̃f�o�b�O�@�\�œ������܂���");
        }
#endif
    }

    /// <summary>����������</summary>
    public void Init(Transform centerPoint, Transform escapePoint)
    {
        _fishMove.SetWayPoint(centerPoint, escapePoint);
        _fishMove.StartMove();
    }

    /// <summary>
    /// ����݂�グ�o�g����Ԃɂ�����
    /// �����ނ�ƂɃq�b�g�������ɌĂ�
    /// </summary>
    public void Capture()
    {
        _fishMove.StopMove();
        // TODO:�ނ�グ���̃A�j���[�V����
    }

    /// <summary>
    /// �����ނ�Ȃ���Ԃɂ��ē�����
    /// </summary>
    public void Escape()
    {
        _fishMove.EscapeMove();
    }

    /// <summary>
    /// �ނ�ꂽ���ɌĂ΂��
    /// </summary>
    public void Caught()
    {
        Debug.Log("�ނ��܂���");
    }
}
