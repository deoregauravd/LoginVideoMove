/*using UnityEngine;
using GLTFast;  // Import GLTFast namespace

public class GLBLoader : MonoBehaviour
{
    public string glbFilePath;  // Path to your GLB file

    private GameObject loadedModel;

    void Start()
    {
        // Load the GLB file
        LoadGLB();
    }

    void LoadGLB()
    {
        // Create an instance of the GLTFast loader
        var gltfLoader = new GltfImport();

        // Instantiate the GameObjectInstantiator
        var instantiator = new GameObjectInstantiator(
            gltfLoader, 
            transform,  // Set the current object's transform as the parent
            new CodeLogger(),  // A logger to handle logs
            new InstantiationSettings()  // Optional settings for instantiation
        );

        // Start loading the GLB model asynchronously
        gltfLoader.Load(glbFilePath, instantiator).ContinueWith(loadTask =>
        {
            if (loadTask.Result)
            {
                // Successfully loaded, instantiate the model
                loadedModel = gltfLoader.GetRoot();
                loadedModel.transform.position = new Vector3(0, 0, 0);  // Position the model at the origin
            }
            else
            {
                Debug.LogError("Failed to load GLB model.");
            }
        });
    }
}
*/
