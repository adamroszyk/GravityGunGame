using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMng : MonoBehaviour
{
    public static LevelMng instance = null;
    public LvlSettings settings;

    #region Methods
    private void Start()
    {
        CheckLevelChange();
    }

    public void CheckLevelChange()
    {
        if (GameMng.instance.Score >= settings.scoreToWin) StartCoroutine(ChangeScene(settings.NextScene, settings.waitTime));
    }

    public IEnumerator ChangeScene(int sceneToLoad, float timeToLoad)
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion
}
