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
            childs[i].Translate(Vector2.left * GameManager.Data.MoveSpeed * Time.deltaTime, Space.World); // �������� �̵�
            if (childs[i].localPosition.x < offset * childs.Length * -0.5f) // �̵��ϴ� ������Ʈ�� x ��ǥ�� ������Ʈ ũ�⸦ �Ѿ��
                childs[i].Translate(Vector2.right * offset * childs.Length); // �ٽ� ���������� �̵������ش�.
            
            //-0.5f �� �ϴ� ������ �������� ���� �߾Ӱ��̶�
            //��ü ���̿��� -0.5f ���ؼ� ȭ�鿡 ������Ʈ�� ����������� �ٽ� ���������� �Ѱ��ִ� ���̴�.
        }
    }
}
