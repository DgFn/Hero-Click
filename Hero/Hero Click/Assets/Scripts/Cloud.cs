using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // ������, ������� ������ �������
    public List<GameObject> Clouds = new List<GameObject>();
  
    //������ ��������
    public void Start()
    {
        StartCloud();
    }


    // �������� �������� � �������� ���������� ��� �����������
    public void StartCloud()
    {

        foreach (GameObject cloud in Clouds)
        {
            Instantiate(cloud, new Vector2(Random.Range((float)-5,-3),Random.Range((float)0,5)), Quaternion.identity);
            FindObjectOfType<CloudsMove>().MoveCloud();
        }
        StartCoroutine(WaitCloud());
    }
    // ������ ����� �������� ����� 10 ���
    IEnumerator WaitCloud()
    {
        yield return new WaitForSeconds(10);
        StartCloud();
    }
}
