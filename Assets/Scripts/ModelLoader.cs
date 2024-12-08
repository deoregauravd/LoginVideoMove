using System.Collections;
using UnityEngine;

public class ModelLoaderWith : MonoBehaviour
{
    public ModelData modelData; // Assign the ScriptableObject in the inspector

    private string assetBundlePath;

    void Start()
    {

        assetBundlePath = Application.streamingAssetsPath + "/" + modelData.modelBundleName;
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

        AssetBundleRequest assetRequest = bundle.LoadAssetAsync<GameObject>(modelData.modeName);
        yield return assetRequest;

        GameObject modelPrefab = assetRequest.asset as GameObject;

        if (modelPrefab != null)
        {

            float randomX = Random.Range(-10f, 10f);
            float randomY = Random.Range(0f, 5f);
            float randomZ = Random.Range(-10f, 10f);


            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);


            Instantiate(modelPrefab, randomPosition, Quaternion.identity);

            Camera.main.transform.position = new Vector3(randomPosition.x, randomPosition.y, randomPosition.z - 20f);
            Camera.main.transform.LookAt(modelPrefab.transform);
        }
        else
        {
            Debug.LogError("Model not found in AssetBundle: " + modelData.modeName);
        }


        bundle.Unload(false);
    }
}


