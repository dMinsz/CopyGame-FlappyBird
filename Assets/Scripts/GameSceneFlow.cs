using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSceneFlow : MonoBehaviour
{
    [Serializable]
    public enum State
    {
        Ready,// 게임준비상태
        Play, // 게임중 상태
        GameOver,// 게임 종료 상태
    }

    private State curState;

    //이벤트 형식으로 구현
    public UnityEvent OnReadyed;
    public UnityEvent OnPlayed;
    public UnityEvent OnGameOvered;

    private void Start()
    {
        ChangeState(State.Ready); // 게임 시작시 준비상태로 세팅
    }

    public void ChangeState(State state)
    {
        curState = state;
        switch (state)
        {
            case State.Ready: 
                OnReadyed?.Invoke();
                GameManager.Data.CurScore = 0;
                break;
            case State.Play: 
                OnPlayed?.Invoke();
                break;
            case State.GameOver:
                OnGameOvered?.Invoke();
                break;
        }
    }

    public void Play()
    {
        ChangeState(State.Play);
    }

    public void GameOver()
    {
        ChangeState(State.GameOver);
    }

    public void Ok()
    {
        SceneManager.LoadScene("TitleScene");
        //타이틀씬으로 넘어가기
    }

}
