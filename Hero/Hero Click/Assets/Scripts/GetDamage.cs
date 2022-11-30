using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDamage : MonoBehaviour
{
    [SerializeField] float Score = 0;
    Text ScoreText;
    // ������������ ������
    public void Start()
    {
        ScoreText = GetComponent<Text>();
        UpdateDisplay();
    }
    //���������� �������
        private void UpdateDisplay()
    {
        string shortScaleNum = PolyLabs.ShortScale.ParseFloat(Score);
        ScoreText.text = shortScaleNum.ToString();
    }
    // ��������� ����� ������� ����� ������������
    public void AddScore(float amount)
    {
        Score += amount;
        UpdateDisplay();
    }
  
}

