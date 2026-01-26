using UnityEngine;

public class FunctionToDesactivate
{
    public static void autoSwitchCanvas(Canvas canvaToSwitch)
    {
        canvaToSwitch.enabled = !canvaToSwitch.enabled;
    }
}
