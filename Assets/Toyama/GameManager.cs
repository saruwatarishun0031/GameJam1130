using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :MonoBehaviour
{
    public bool _start = false;//true���ɃQ�[���X�^�[�g
    public float _time = 0f;
    [SerializeField,Header("�Q�[���I�[�o�[����")] float _gameOverTime = 5f;
    [SerializeField,Header("�Q�[���I�[�o�[���̃p�l��")] GameObject _panel;

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        if(_start)
        {
            _time += Time.deltaTime;
            if (_time > _gameOverTime)
            {
                GameOver();
            }
        }
        else
        {
            return;
        }
        
    }
    public void GameStart()
    {
        StartCoroutine(Hoge());
        IEnumerator Hoge()
        {
            yield return new WaitUntil(() => Input.GetButtonDown("Jump"));
            Debug.Log("Start");
            _start = true;
        }
    }
    public void GameOver()
    {
        _start = false;
        _time = 0f;
        Debug.Log("iikanzinopanel");
        _panel.SetActive(true);
        
    }
}

