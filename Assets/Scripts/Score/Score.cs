using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private float _currentValue;
    private float _maxValueRecord;
    private bool _isNewRecord;

    public Action<float, bool> OnScoreUpdate;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Score")) PlayerPrefs.SetFloat("Score", 0);
        _text = GetComponent<TextMeshProUGUI>();
        _maxValueRecord = PlayerPrefs.GetFloat("Score");
        _isNewRecord = false;
        _currentValue = 0;
        _text.text = _currentValue.ToString();
        
        EventManager.Instance.OnDeadEnemy += IncreasedScore;
        EventManager.Instance.OnDeadPlayer += UpdateRecordIfNeed;
    }
    
    private void IncreasedScore(float value)
    {
        _currentValue += value;
        _text.text = _currentValue.ToString();
    }

    private void UpdateRecordIfNeed()
    {
        if (_maxValueRecord < _currentValue)
        {
            _isNewRecord = true;
            PlayerPrefs.SetFloat("Score", _currentValue);
        }
        OnScoreUpdate.Invoke(_currentValue, _isNewRecord);
    }


    private void OnDestroy()
    {
        EventManager.Instance.OnDeadEnemy -= IncreasedScore;
        EventManager.Instance.OnDeadPlayer -= UpdateRecordIfNeed;
    }
}
