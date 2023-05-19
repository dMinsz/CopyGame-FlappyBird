using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField]
    Transform[] childs;
    [SerializeField]
    private float offset;

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].Translate(Vector2.left * GameManager.Data.MoveSpeed * Time.deltaTime, Space.World); // 왼쪽으로 이동
            if (childs[i].localPosition.x < offset * childs.Length * -0.5f) // 이동하는 오브젝트의 x 좌표가 오브젝트 크기를 넘어가면
                childs[i].Translate(Vector2.right * offset * childs.Length); // 다시 오른쪽으로 이동시켜준다.
            
            //-0.5f 를 하는 이유는 포지션의 값이 중앙값이라
            //전체 길이에서 -0.5f 곱해서 화면에 오브젝트가 사라지기전에 다시 오른쪽으로 넘겨주는 것이다.
        }
    }
}
