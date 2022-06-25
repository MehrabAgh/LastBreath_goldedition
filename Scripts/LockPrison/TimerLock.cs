using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerLock : MonoBehaviour
{
    [SerializeField] private float Timer;
    private float Min = 0f, Sec = 0f;
    private  string res;
    [SerializeField] private Text ren;
    public bool _isOverTime , _isStartTime;

    public void StarterTimer()
    {
        _isStartTime = true;
    }
    private void Formating(float _time, float min ,  float sec , out string result)
    {
         min = Mathf.FloorToInt(_time / 60);
         sec = Mathf.FloorToInt(_time % 60);
        result = min + ":" + sec;
    }

    private void Update()
    {
        if (_isStartTime && !_isOverTime)
        {
            Timer -= Time.deltaTime;
            Formating(Timer, Min, Sec,out res);
            ren.text=res;
        }
        if(Timer <= 0)
        {
            _isOverTime = true;
        }
        if (_isOverTime) {
            SceneManager.LoadScene("t_mhb");
        }
    }
}
