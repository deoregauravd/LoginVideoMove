using System.Collections;
using UnityEngine;

public class ModelLoaderWithSO : MonoBehaviour
{
    public ModelData modelData; // Assign the ScriptableObject in the inspector

    private string assetBundlePath;

    void Start()
    {
        // Construct the Asset Bundle path (adjust for your setup)
        assetBundlePath = Application.streamingAssetsPath + "/" + modelData.modelBundleName;

        // Start loading the model
        StartCoroutine(LoadModelFromAssetBundle());
    }

    IEnumerator LoadModelFromAssetBundle()
    {
        // Load the Asset Bundle
        AssetBundleCreateRequest bundleRequest = AssetBundle.LoadFromFileAsync(assetBundlePath);
        yield return bundleRequest;

        AssetBundle bundle = bundleRequest.assetBundle;

        if (bundle == null)
        {
            Debug.LogError("Failed to load AssetBundle: " + modelData.modelBundleName);
            yield break;
        }

        // Load the specific asset (model) from the Asset Bundle
        AssetBundleRequest assetRequest = bundle.LoadAssetAsync<GameObject>(modelData.modeName);
        yield return assetRequest;

        GameObject modelPrefab = assetRequest.asset as GameObject;

        if (modelPrefab != null)
        {
            // Instantiate the model in the scene
            Instantiate(modelPrefab);
        }
        else
        {
            Debug.LogError("Model not found in AssetBundle: " + modelData.modeName);
        }

        // Optionally unload the Asset Bundle to free memory
        bundle.Unload(false);
    }
}
