using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    // Start is called before the first frame update
    public async void Click()
    {
        WWWForm form = new WWWForm();
        if (Application.platform == RuntimePlatform.Android)
        {
            form.AddField("id", "test_android");
        }
        else
        {
            form.AddField("id", "test_pc");
        }


   
      await Request.AsyncPostRequest(ServerHelper.SERVERPATH, new WWWForm());   

    }

    public void WaitTime()
    {
        //매칭 관련 다이얼로그를 띄워주는 메소드 구현 필요,.

    }
    // Update is called once per frame

}
