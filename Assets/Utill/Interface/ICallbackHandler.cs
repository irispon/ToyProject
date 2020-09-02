using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICallBackHandler
{
    void Call(string message,ICallBack callback);
}
