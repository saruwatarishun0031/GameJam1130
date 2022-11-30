using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����N�����邽�߂̃W�F�l���[�^
/// �X�e�[�W�̕������ɔz�u����
/// </summary>
public class Generator : MonoBehaviour
{
    /// <summary>�W�F�l���[�^�[�̏��</summary>
    public bool IsActive = false;

    IEnumerator Start()
    {
        // �O������I���ɂ���܂ŃW�F�l���[�^���N�������Ȃ�
        yield return new WaitUntil(() => IsActive);

        while (IsActive)
        {
            Debug.Log("���𐶐�");
            yield return 0.1f;
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
