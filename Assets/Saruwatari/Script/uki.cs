using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class uki : MonoBehaviour
{
    Rigidbody2D _re;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(new Vector3(0, PlayerController.Instance.Pw / 10, 0), 1f).SetRelative(true);
        Debug.Log(PlayerController.Instance.Pw);
    }

    // Update is called once per frame
    void Update()
    {
        //_re = GetComponent<Rigidbody2D>();
        //Vector2 force = new Vector2(0, Pw * 1000);
        //_re.AddForce(force);
        //Debug.Log(force);


        //Vector3 lazerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
        //lazerPos.x += Pw * Time.deltaTime; //x���W��speed�����Z
        //transform.position = lazerPos; //���݂̈ʒu���ɔ��f������

    }
}
