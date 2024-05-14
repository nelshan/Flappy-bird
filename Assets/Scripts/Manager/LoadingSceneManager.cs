using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName : byte
{
    Bootstrap,
    Menu,
    FlappyBird,
}

public class LoadingSceneManager : MonoBehaviour
{
    public SceneName SceneActive => m_sceneActive;

    private SceneName m_sceneActive;

    public static LoadingSceneManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(SceneName sceneToLoad)
    {
        StartCoroutine(Loading(sceneToLoad));
    }

    // Coroutine for the loading effect. It uses an alpha in/out effect
    private IEnumerator Loading(SceneName sceneToLoad)
    {
        LoadingFadeEffect.Instance.FadeIn();

        // Here the player still sees the loading screen
        yield return new WaitUntil(() => LoadingFadeEffect.s_canLoad);

        LoadSceneLocal(sceneToLoad);

        // Because the scenes are not heavy, we can just wait a second and continue with the fade.
        // In case the scene is heavy instead we should use additive loading to wait for the
        // scene to load before we continue
        yield return new WaitForSeconds(1f);

        LoadingFadeEffect.Instance.FadeOut();
    }

    // Load the scene using the regular SceneManager
    private void LoadSceneLocal(SceneName sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.ToString());
        switch (sceneToLoad)
        {
            case SceneName.Menu:
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlayMusic(AudioManager.MusicName.intro);//play the intro music on menu scene
                break;
        }
    }
}

