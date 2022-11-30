using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class uki : MonoBehaviour
{
    [SerializeField]
    Collider2D a;
    public bool _duel = false;
    FishUnit unit;
    // Start is called before the first frame update
    //シングルトンパターン（簡易型、呼び出される）
    public static uki Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //シングルトン（ここまで）

    void Start()
    {
        
        //Debug.Log(PlayerController.Instance.Pw);
    }

    // Update is called once per frame
    void Update()
    {
       if (PlayerController.Instance.c == true)
        {
            Debug.Log("r");
            if (unit == null)
            {
                return;
            }
            unit.Escape();
            Debug.Log("C");
            PlayerController.Instance.c = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        unit = collision.gameObject.GetComponent<FishUnit>();
        unit.Capture();
        a.enabled = false;
        _duel = true; 
    }

    public void syuppatu()
    {
        transform.DOLocalMove(new Vector3(0, PlayerController.Instance.Pw / 10, 0), 1f).SetRelative(true);
    }

    public void Desu()
    {
        Destroy(this.gameObject);
        PlayerController.Instance.Battru = false;
    }
}
