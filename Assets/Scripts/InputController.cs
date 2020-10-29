using UnityEngine;

public class InputController
{

    readonly CallBack callBack;

    public InputController(CallBack callBack)
    {
        this.callBack = callBack;
    }

    public void GetInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            callBack();
        }
    }
}
