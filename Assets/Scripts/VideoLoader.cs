using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public VideoData videoData;    

    private static Dictionary<string, AssetBundle> loadedBundles = new Dictionary<string, AssetBundle>();

    public void PlayVideo()
    {
        if (videoPlayer.isPlaying)
        {
           
            return;
        }

        StartCoroutine(LoadAndPlayVideo());
    }

    public void PauseVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            
        }
        else
        {
          
        }
    }

    public void StopVideo()
    {
        if (videoPlayer.isPlaying || videoPlayer.isPaused)
        {
            videoPlayer.Stop();
            Debug.Log("Video stopped.");
        }
        else
        {
            Debug.LogWarning("Cannot stop, the video is not playing.");
        }
    }

    private IEnumerator LoadAndPlayVideo()
    {
        string bundlePath = Application.streamingAssetsPath + "/" + videoData.bundleName;

        AssetBundle bundle;

        
        if (loadedBundles.TryGetValue(videoData.bundleName, out bundle))
        {
           // alreadt loaded
        }
        else
        {
          
            AssetBundleCreateRequest bundleRequest = AssetBundle.LoadFromFileAsync(bundlePath);
            yield return bundleRequest;

            bundle = bundleRequest.assetBundle;
            if (bundle == null)
            {
                Debug.LogError("Failed to load AssetBundle!");
                yield break;
            }

            //cache
            loadedBundles[videoData.bundleName] = bundle;
          
        }


        AssetBundleRequest assetRequest = bundle.LoadAssetAsync<VideoClip>(videoData.videoClipName);
        yield return assetRequest;

        VideoClip videoClip = assetRequest.asset as VideoClip;
        if (videoClip == null)
        {
            Debug.LogError("Failed to load VideoClip!");
            yield break;
        }

  
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
        Debug.Log("Video started playing.");
    }

    private void OnDestroy()
    {
       // destroy extra fun
        foreach (var kvp in loadedBundles)
        {
            kvp.Value.Unload(false);
        }

        loadedBundles.Clear();
        Debug.Log("All AssetBundles unloaded.");
    }
}
