/*using UnityEngine;
using UnityEngine.Video;
using GLTFast; 
public class VideoLoader : MonoBehaviour
{
    public AssetPaths assetPaths; 

    void Start()
    {
        
        LoadVideo();
    
    }

    void LoadVideo()
    {
        
        string videoPath = assetPaths.videoBundlePath;
        AssetBundle videoBundle = AssetBundle.LoadFromFile(videoPath);

        if (videoBundle != null)
        {
            VideoClip videoClip = videoBundle.LoadAsset<VideoClip>("VideoClipName");
           
            VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.clip = videoClip;
        }
        else
        {
            Debug.LogError("Failed to load video bundle.");
        }
    }

}
*/