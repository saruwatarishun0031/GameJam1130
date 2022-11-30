using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����N�����邽�߂̃W�F�l���[�^
/// �X�e�[�W�̕������ɔz�u����
/// </summary>
public class Generator : MonoBehaviour
{
    //[SerializeField] FishManager _fishManager;
    /// <summary>�������鋛�̃v���n�u</summary>
    [SerializeField] GameObject[] _fishPrefabs;
    /// <summary>�S�Ă̋����ڎw����ʒ����̃|�C���g</summary>
    [SerializeField] Transform _centerPoint;
    /// <summary>�����ƂɃ����_���ȓ����|�C���g�Ɍ������悤�ɂ���</summary>
    [SerializeField] Transform[] _escapePoints;

    /// <summary>�W�F�l���[�^�[�̏��</summary>
    public bool IsActive = false;

    IEnumerator Start()
    {
        // �O������I���ɂ���܂ŃW�F�l���[�^���N�������Ȃ�
        yield return new WaitUntil(() => IsActive);

        while (IsActive)
        {
            int fr = Random.Range(0, _fishPrefabs.Length);
            int pr = Random.Range(0, _escapePoints.Length);

            // TODO:�S���̋������ʂ��ČĂԂ��̂Ȃ̂�static�ȃN���X��ʓr����A��������wayPoint��������
            //      ������������WayPoint��ݒ肷��悤�ɂ���
            // ���𐶐����ď������������ĂԁB
            GameObject go = Instantiate(_fishPrefabs[fr], transform.position, Quaternion.identity);
            FishUnit unit = go.GetComponent<FishUnit>();
            unit.Init(_centerPoint.position, _escapePoints[pr]);
            
            // �Ǘ�������
            //_fishManager.AddFishList(unit);
            
            yield return new WaitForSeconds(3.0f);
        }
        Debug.Log("�W�F�l���[�^���~���܂�");
    }

    void Update()
    {
#if UNITY_EDITOR
        // �f�o�b�O�p�A��Ԃ�؂�ւ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsActive = !IsActive;
            Debug.Log("�W�F�l���[�^�̃f�o�b�O�@�\�ŏ�Ԃ�؂�ւ��܂���:" + IsActive);
        }
#endif
    }
}
