using UnityEngine;


public static class BaseClassExtension
{
    public static float HpAmount(BaseClass variable)
    {
        return Mathf.Clamp01(Mathf.InverseLerp(0, variable.StrLife, variable.Life));
    }
}

