using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("ウキ")]
    GameObject _uki;
    [SerializeField, Tooltip("ウキ")]
    Collider2D _ukic;
    [SerializeField, Tooltip("投げる強さ")]
    Slider PwGauge;
    [SerializeField, Tooltip("魚のHP")]
    Slider HP;
    uki _u;
    public float Pw = 1;
    float MaxPw = 100;
    public bool Battru;
    int i = 15;
    int d　= 15;
    float b;
    bool a = false;
    public bool c = false;
    // Start is called before the first frame update
    //シングルトンパターン（簡易型、呼び出される）
    public static PlayerController Instance;

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
        _u.GetComponent<uki>();
        Battru = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //float mousex = Input.GetAxis("Mouse X");
        //transform.Rotate(transform.position,mousex);
        R();
        Hit();
        Uki();
        Debug.Log(b);
        if (a == true)
        {
            b += Time.deltaTime;
        }
        HP.value = (int)i / (int)d;
    }

    void Uki()
    {

        if (Input.GetButton("Fire2") && Battru == false)
        {
            PwGauge.gameObject.SetActive(true);
            if (Pw < 100)
            {
                Pw += 0.1f;
                PwGauge.value = (float)Pw / (float)MaxPw;
            }
            else if (Pw > 100)
            {
                Pw = 1f;
                PwGauge.value = (float)Pw / (float)MaxPw;
            }
        }

        if (Input.GetButtonUp("Fire2") && Battru == false)
        {
            GameObject Mazuru = Instantiate(_uki, transform.position, Quaternion.identity);
            Battru = true;
            _ukic.enabled = true;
            //Instantiate(_uki,gameObject.Mazuru , Quaternion.identity);
            StartCoroutine("HideSreider");
            uki.Instance.syuppatu();


        }

       // Debug.Log(Pw);

    }

    void Hit()
    {
        if (uki.Instance == null)
        {
            return;
        }
        if (uki.Instance._duel == true)
        {
            Debug.Log(i);
            uki.Instance._duel = false;
            a = true;
            HP.gameObject.SetActive(true);
            
        }

        if (Input.GetButtonDown("Jump") && uki.Instance._duel == false)
        {
            i -= 1;
            //Debug.Log(i);
        }

        if (b > 5)
        {
            b = 0;
            a = false;
            c = true;
            HP.gameObject.SetActive(false);
            Battru = false;
        }

        if (i == 0)
        {
            _u.unit.SetScore();
            Debug.Log("勝利");
            Battru = false;
            HP.gameObject.SetActive(false);
            uki.Instance.Desu();
        }
    }

    private void R()
    {
        if (Input.GetKeyDown("w"))
        {
            uki.Instance.Desu();
        }
    }


    IEnumerator HideSreider()
    {
        yield return new WaitForSeconds(1);
        PwGauge.gameObject.SetActive(false);

    }

    IEnumerator D()
    {
        yield return new WaitForSeconds(1);
        uki.Instance.Desu();

    }

}
