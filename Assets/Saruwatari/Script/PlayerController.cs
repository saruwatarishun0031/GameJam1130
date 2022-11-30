using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("�E�L")]
    GameObject _uki;
    [SerializeField, Tooltip("�E�L�̏o��ꏊ")]
    GameObject Mazuru;
    [SerializeField, Tooltip("�����鋭��")]
    Slider PwGauge;
    public float Pw = 1;
    float MaxPw = 100;
    public bool Battru;
    // Start is called before the first frame update
    //�V���O���g���p�^�[���i�ȈՌ^�A�Ăяo�����j
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
    //�V���O���g���i�����܂Łj


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
