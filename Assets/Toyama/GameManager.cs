using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool _start = false;//true時にゲームスタート
    [SerializeField] float _time = 60f;
    private bool _stop = false;
    public int _largeCount = 0;
    public int _midiumCount = 0;
    public int _smailCount = 0;
    [SerializeField] GameObject _taitl;
    [SerializeField, Header("タイマー")] Text _timeText;
    [SerializeField, Header("魚大")] Text _largeText;
    [SerializeField, Header("魚中")] Text _midiumText;
    [SerializeField, Header("魚小")] Text _smailText;
    [SerializeField, Header("魚大")] Text _largeText2;
    [SerializeField, Header("魚中")] Text _midiumText2;
    [SerializeField, Header("魚小")] Text _smailText2;
    [SerializeField, Header("プッシュテキスト")] GameObject _pushText;
    [SerializeField, Header("ゲームオーバー時間")] float _gameOverTime = 0.5f;
    [SerializeField, Header("ゲームオーバー時のパネル")] GameObject _panel;

    private void Start()
    {
        GameStart();

    }

    private void Update()
    {
        _timeText.text = _time.ToString("F1");
        _largeText.text = _largeCount.ToString();
        _midiumText.text = _midiumCount.ToString();
        _smailText.text = _smailCount.ToString();
        _largeText2.text = _largeCount.ToString();
        _midiumText2.text = _midiumCount.ToString();
        _smailText2.text = _smailCount.ToString();

        if (_start)
        {
            if (!_stop)
            {
                _time -= Time.deltaTime;
            }
            if (_time < _gameOverTime)
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
        if (i == 3)
        {
            _largeCount++;
        }
        else if (i == 2)
        {
            _midiumCount++;
        }
        else if (i == 1)
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
            _taitl.SetActive(false);
            _pushText.SetActive(false);
            SoundManager.Instance.Play("BGM_ゲーム中");
        }
    }
    public void GameOver()
    {
        SoundManager.Instance.Play("BGM_ゲームオーバー");
        _panel.SetActive(true);
        //_largeText.GetComponent<RectTransform>().position = new Vector3(-270, -41, 0);
        //_midiumText.GetComponent<RectTransform>().position = new Vector3(41, -41, 0);
        //_smailText.GetComponent<RectTransform>().position = new Vector3(-358, -41, 0);
        //_largeText.gameObject.transform.position =  new Vector2(-270, -41);
        //_midiumText.gameObject.transform.position = new Vector2(41, -41);
        //_smailText.gameObject.transform.position = new Vector2(-358, -41);
    }
}

