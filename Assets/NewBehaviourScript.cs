using UnityEngine;

[CreateAssetMenu(fileName = "NewVideoData", menuName = "Video Data", order = 1)]
public class VideoData : ScriptableObject
{
    public string bundleName;     
    public string videoClipName; 
}
