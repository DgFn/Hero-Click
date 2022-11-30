using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    float speed = 1.2f;
    //�������� �� ����� �� ����� ����� ����� ���������
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(300, 3), speed*Time.deltaTime);
    }
    //������ ����������� �������
    public void MoveCloud()
    {
        StartCoroutine(DestroyCloud());
    }
    // ����������� �������� ����� 9 ���
    IEnumerator DestroyCloud()
    {
        yield return new WaitForSeconds(9);
        Destroy(gameObject);
    }

}
