using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class DeckMakerController : MonoBehaviour
{
    #region Variables
    [Header("Panel")]
    [SerializeField] private GameObject deckMakerPanel;
    [Space]

    [Header("Elemental Card Pools")]
    [SerializeField] private List<ThemeData> allThemes = new List<ThemeData>();
    [Space]

    [Header("Deck Total Settings")]
    [HideInInspector] public int totalCount;
    [SerializeField] private TMP_Text totalCountText;
    [Space]

    [Header("Elemental Deck Settings")]
    [SerializeField] private int maxCardPerTheme;
    [SerializeField] private int maxTotalCard;
    [Space]

    [Header("Elemental Deck Apply Check")]
    [SerializeField] private GameObject applyErrorText;
    private Coroutine applyErrorCoroutine;

    #endregion
    #region GeneratePlayerDeck
    public void GeneratePlayerDeck()
    {
        for (int i = 0; i < allThemes.Count; i++)
        {
            if (allThemes[i].cardCount > 0)
            {
                List<CardScriptableObject> cardPool = new List<CardScriptableObject>(allThemes[i].cards);

                for (int k = 0; k < allThemes[i].cardCount; k++)
                {
                    if (cardPool.Count == 0) break;

                    int randomIndex = Random.Range(0, cardPool.Count);

                    DeckController.instance.deckToUse.Add(cardPool[randomIndex]);

                    cardPool.RemoveAt(randomIndex);
                }
            }
        }

        deckMakerPanel.SetActive(false);
    }
    #endregion
    #region Add-Remove Card
    public void AddCard(int themeIndex)
    {
        if (totalCount >= maxTotalCard) return;

        if (allThemes[themeIndex].cardCount >= maxCardPerTheme) return;

        allThemes[themeIndex].cardCount++;
        totalCount++;

        UpdateUI(themeIndex);
    }
    public void RemoveCard(int themeIndex)
    {
        if (allThemes[themeIndex].cardCount <= 0) return;

        allThemes[themeIndex].cardCount--;
        totalCount--;

        UpdateUI(themeIndex);
    }
    #endregion
    #region UpdateUI
    public void UpdateUI(int themeIndex)
    {
        allThemes[themeIndex].cardCountText.text = $"{allThemes[themeIndex].cardCount.ToString()} X";

        if (totalCountText != null)
        {
            totalCountText.text = $"{totalCount.ToString()} / {maxTotalCard.ToString()}";
        }
    }
    #endregion
    #region Apply-Close Button
    public void ApplyButton()
    {
        if (totalCount == maxTotalCard)
        {
            DeckController.instance.deckToUse.Clear();
            GeneratePlayerDeck();
        }
        else
        {
            if (applyErrorCoroutine != null)
            {
                StopCoroutine(applyErrorCoroutine);
            }

            applyErrorText.SetActive(true);

            applyErrorCoroutine = StartCoroutine(applyErrorClose());
        }
    }
    IEnumerator applyErrorClose()
    {
        yield return new WaitForSeconds(2f);
        applyErrorText.SetActive(false);
        applyErrorCoroutine = null;
    }
    public void CloseButton()
    {
        if (totalCount != maxTotalCard)
        {
            totalCount = 0;

            for (int i = 0; i < allThemes.Count; i++)
            {
                allThemes[i].cardCount = 0;
                UpdateUI(i);
            }
        }
        if (applyErrorText.activeInHierarchy)
        {
            applyErrorText.SetActive(false);
        }
        deckMakerPanel.SetActive(false);
    }
    #endregion
}
#region ThemeData Class
[System.Serializable]
public class ThemeData
{
    [Header("Card Data")]
    public string name;
    [HideInInspector] public int cardCount;
    public TMP_Text cardCountText;

    [Header("Elemental Cards")]
    public List<CardScriptableObject> cards = new List<CardScriptableObject>();
}
#endregion