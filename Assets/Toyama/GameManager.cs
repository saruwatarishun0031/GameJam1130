using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager :MonoBehaviour
{
    public bool _start = false;//true時にゲームスタート
    public float _time = 0f;
    private bool _stop = false;
    public int _largeCount = 0;
    public int _midiumCount = 0;
    public int _smailCount = 0;
    [SerializeField, Header("タイマー")] Text _timeText;
    [SerializeField, Header("魚大")] Text _largeText;
    [SerializeField, Header("魚中")] Text _midiumText;
    [SerializeField, Header("魚小")] Text _smailText;
    [SerializeField,Header("ゲームオーバー時間")] float _gameOverTime = 5f;
    [SerializeField,Header("ゲームオーバー時のパネル")] GameObject _panel;

    private void Start()
    {
        GameStart();

    }

    private void Update()
    {
        if(_start)
        {
            _largeText.text = _largeCount.ToString();
            _midiumText.text = _midiumCount.ToString();
            _smailText.text = _smailCount.ToString();
            
            if (!_stop)
            {
                _time += Time.deltaTime;
                _timeText.text = _time.ToString("F1");
            }
            if (_time > _gameOverTime)
            {
                _stop = true;
                GameOver();
            }
        }
        else
        {
            return;
        }
        
    }
    public void FishCount(int i)
    {
        if(i == 3)
        {
            _largeCount++;
        }
        else if(i == 2)
        {
            _midiumCount++;
        }
        else if(i == 1)
        {
            _smailCount++;
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

