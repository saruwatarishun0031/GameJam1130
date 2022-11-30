using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ���̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class FishMove : MonoBehaviour
{
    // ���̑��x
    [SerializeField] float _speed;

    // �ނ�Ƃ̍��W�A���I��null�ɂȂ�
    Transform _rod;
    
    // �����ڎw���n�_
    // _centerPoint�Ɍ����Đi��ŁA���΂炭�o������_escapePoint�Ɍ����Đi��
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
    /// �������A�����ڎw���n�_��n��
    /// �W�F�l���[�^�[������Ăԑz��ɂȂ��Ă���
    /// </summary>
    public void SetWayPoint(Vector3 centerPoint, Transform escapePoint)
    {
        _centerPoint = centerPoint;
        _escapePoint = escapePoint;
    }

    /// <summary>�ړ����J�n������</summary>
    public void StartMove()
    {
        _seq = DOTween.Sequence();
        _seq.AppendCallback(() => transform.rotation = Quaternion.FromToRotation(Vector3.up, _centerPoint - transform.position));
        _seq.Append(transform.DOMove(_centerPoint, _speed));
        _seq.AppendCallback(() => transform.rotation = Quaternion.FromToRotation(Vector3.up, _escapePoint.position - transform.position));
        _seq.Append(transform.DOMove(_escapePoint.position, _speed));
    }

    /// <summary>
    /// �Ƃ��߂��ɂ����������Ă���
    /// ���̃��\�b�h�͒ނ�Ƃ�null����Ȃ��ꍇ�ɂ̂݌Ă΂��
    /// </summary>
    void ApproachRod()
    {
        // �s���𒆒f����̂�Kill����
        if (_seq != null) _seq.Kill();
        
        // �ނ�Ƃ�ڎw��
        _seq.Append(transform.DOMove(_rod.position, _speed));
    }

    /// <summary>
    /// ���݂̏�Ԃ���WayPoint��ڎw���Ă̈ړ��ɐ؂�ւ���
    /// ���݂͒ނ�Ƃɑ��̋������������ꍇ�ɂ̂݌Ă΂��z��
    /// </summary>
    void ChangeWayPointMove()
    {
        // �s���𒆒f����̂�Kill����
        if (_seq != null) _seq.Kill();

        // �ނ�Ƃ�ڎw��
        _seq.Append(transform.DOMove(_escapePoint.position, _speed));
    }

    /// <summary>
    /// �ړ����~�߂�
    /// �a�ɐH���������ɌĂԑz��ɂȂ��Ă���
    /// </summary>
    public void StopMove()
    {
        _seq.Kill();
    }

    /// <summary>
    /// �����o���Ƃ��̃A�j���[�V����
    /// �ނ�o�g���ɋ��������ē����o���Ƃ��ɌĂ�
    /// </summary>
    public void EscapeMove()
    {
        // �H��������ɂ��̃��\�b�h���Ă΂��̂�_seq�̓L������Ă���\�肾��
        // �ꉞ������null�`�F�b�N�����Ă����A�O���Ɉˑ����Ă��Ȃ��̂ŕs�v�Ȃ����
        if (_seq != null) _seq.Kill();

        // TODO:������Ƃ��̃A�j���[�V���������
        //      ��������ɃR�[���o�b�N��ǉ����ĉ����ł���悤�ɂȂ��Ă���̂ŕK�v�Ȃ�ǉ�����
        Sequence escapeSeq = DOTween.Sequence();
        escapeSeq.Append(transform.DOScale(Vector3.zero, 0.5f));
        escapeSeq.AppendCallback(() => Debug.Log("�ɂ��܂���"));
    }
}
