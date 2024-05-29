 using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private GameObject _spinner;
    [SerializeField] private GameObject _acknowledge;
    [SerializeField] private GameObject _loaderCanvas;
    private AsyncOperation scene;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName) {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName) {
        scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

        while (scene.progress < 0.9f)
        {
            yield return null; // Wait for the next frame
        }

        // Simulate a delay of 100 milliseconds
        yield return new WaitForSeconds(5f);

        _spinner.SetActive(false);
        _acknowledge.SetActive(true);
    }

    public void OnAcknowledge() {
        if (scene != null) {
            scene.allowSceneActivation = true;
        }

        _loaderCanvas.SetActive(false); 
    }
}
