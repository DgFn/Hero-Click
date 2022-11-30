using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickDamage : MonoBehaviour
{  
    private bool move;
    private Vector2 randomVector;
    //������ �������� �����, ����� ��� ���������
    private void Update()
    {
        if (!move) return;
        transform.Translate(randomVector * Time.deltaTime);
    }
    // ������������ ������� ��������, ���� ��  ����������� ������, ���������� ����� �������� � ��������� ���������� � ��� ������� ����� ������� �����
    public void StartMotion(string scoreIncrease)
    {
        transform.localPosition = Vector2.zero;
        GetComponent<Text>().text = "-" + scoreIncrease;
        randomVector = new Vector2(Random.Range(0, (float)0.5), Random.Range(1,2));
        move = true;
        GetComponent<Animation>().Play();
    }


  

}
