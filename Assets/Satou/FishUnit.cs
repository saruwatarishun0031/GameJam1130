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

    GameManager _gameManager;

    void Awake()
    {
        _fishMove = GetComponent<FishMove>();
    }

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {

    }

    /// <summary>����������</summary>
    public void Init(Vector3 centerPoint, Transform escapePoint)
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

    public void SetScore()
    {
        _gameManager.FishCount(_size);
    }
}
