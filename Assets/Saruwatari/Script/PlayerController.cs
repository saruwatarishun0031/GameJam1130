using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("ウキ")]
    GameObject _uki;
    [SerializeField, Tooltip("ウキの出る場所")]
    GameObject Mazuru;
    [SerializeField, Tooltip("投げる強さ")]
    Slider PwGauge;
    public float Pw = 1;
    float MaxPw = 100;
    public bool Battru;
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
        Battru = false;
    }

    // Update is called once per frame
    void Update()
    {
        //float mousex = Input.GetAxis("Mouse X");
        //transform.Rotate(transform.position,mousex);

        hit();
        Uki();

        
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

            //Instantiate(_uki,gameObject.Mazuru , Quaternion.identity);
            StartCoroutine("HideSreider");
        }

       // Debug.Log(Pw);

    }

    void hit()
    {

    }

    IEnumerator HideSreider()
    {
        yield return new WaitForSeconds(3);
        PwGauge.gameObject.SetActive(false);

    }
}
