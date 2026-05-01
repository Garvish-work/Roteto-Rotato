using UnityEngine;

[CreateAssetMenu (fileName = "Ads config", menuName = "Scriptable/Ads config")]
public class AdsConfig : ScriptableObject
{
    public int playCount = 0;
    public int maxPlayCount = 3;

    public string interstitialAdUnitId;
    public string rewardedAdUnitId;
}
