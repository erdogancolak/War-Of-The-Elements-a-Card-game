using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    #region Variables
    [SerializeField] private List<ButtonItem> buttonList = new List<ButtonItem>();

    [Header("Game Scene Index")]
    [SerializeField] private string SceneName;

    [Header("DeckErrorText")]
    [SerializeField] private GameObject deckErrorText;
    [SerializeField] private float deckErrorTimer;
    private Coroutine applyDeckErrorCoroutine;

    [Header("Options Panel")]
    [SerializeField] private GameObject OptionsPanel;

    [Header("DeckControl Panel")]
    [SerializeField] private GameObject DeckControlPanel;
    #endregion
    #region Start
    void Start()
    {
        for(int i = 0;i < buttonList.Count;i++)
        {
            buttonList[i].button.onClick.RemoveAllListeners();
        }

        buttonList[0].button.onClick.AddListener(PlayButton);
        buttonList[1].button.onClick.AddListener(OptionsButton);
        buttonList[2].button.onClick.AddListener(ExitButton);
        buttonList[3].button.onClick.AddListener(DeckButton);
    }
    #endregion
    #region Play Button
    public void PlayButton()
    {
        Animator animator = buttonList[0].button.GetComponent<Animator>();
        animator.SetTrigger("Clicked");

        if (DeckController.instance.deckToUse.Count == 40)
        {
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            if (applyDeckErrorCoroutine != null) return;

            deckErrorText.SetActive(true);

            applyDeckErrorCoroutine = StartCoroutine(DeckErrorTextClose());
        }
    }

    IEnumerator DeckErrorTextClose()
    {
        yield return new WaitForSeconds(deckErrorTimer);

        deckErrorText.SetActive(false);

        applyDeckErrorCoroutine = null;
    }
    #endregion
    #region Options Button
    public void OptionsButton()
    {
        Animator animator = buttonList[1].button.GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        OptionsPanel.SetActive(true);
    }
    #endregion
    #region Exit Button
    public void ExitButton()
    {
        Animator animator = buttonList[2].button.GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        Application.Quit();
    }
    #endregion
    #region Deck Button
    public void DeckButton()
    {
        Animator animator = buttonList[3].button.GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        DeckControlPanel.SetActive(true);
    }
    #endregion
    #region LinkedIn Button
    public void OpenLinkedIn(string url)
    {
        Application.OpenURL(url);
    }
    #endregion
}
#region ButtonItem
[System.Serializable]
public class ButtonItem
{
    public string name;
    public Button button;
}
#endregion
