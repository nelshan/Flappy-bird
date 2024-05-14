using UnityEngine;
using System.Collections;

public class GoToFlappyBird : MonoBehaviour
{
    bool isLoading = false;

    //private void Start()
    //{
        //AudioManager.Instance.SwitchToGameplayMusic();
    //}
    void Update()
    {
        // Check for mouse click or touch input
        if (!isLoading && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)))
        {
            //AudioManager.Instance.PlaySoundEffect(sfx put the audio name here);
            isLoading = true;
            StartCoroutine(LoadSceneWithFade());
        }
    }

    IEnumerator LoadSceneWithFade()
    {
        // Start the fade out effect
        LoadingFadeEffect.Instance.FadeOut();

        yield return new WaitForSeconds(1f);
        // Load the FlappyBird scene
        LoadingSceneManager.Instance.LoadScene(SceneName.FlappyBird);

        // Wait for the scene to load
        //yield return new WaitUntil(() => LoadingFadeEffect.s_canLoad);

        // Start the fade in effect
        LoadingFadeEffect.Instance.FadeIn();
        //AudioManager.Instance.SwitchToGameplayMusic();//player gameplayer mucic on going to FlappyBird scene

        // Deactivate the loading background image
        LoadingFadeEffect.Instance.m_loadingBackground.gameObject.SetActive(false);

        isLoading = false;
    }
}




