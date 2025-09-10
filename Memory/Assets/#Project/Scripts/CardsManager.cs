using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeFaceDown = 1f;
    List<CardBehavior> deck;
    Color[] colors;
    public int combinasonFound = 0;

    private CardBehavior memoCard = null;

    private WinManager winManager;
    private VictoryManager victoryManager;

    public void Initialize(List<CardBehavior> deck, Color[] colors, VictoryManager victoryManager)
    {
        this.colors = colors;
        this.deck = deck;
        this.victoryManager = victoryManager;

        memoCard = null;
        combinasonFound = 0;

        int colorIndex, cardIndex;
        List<int> colorsAlreadyInGame = new List<int>();
        List<CardBehavior> cards = new List<CardBehavior>(deck);

        /// Exercice
        // //Copie du tableau de couleurs en une liste et du deck
        // List<Color> colorsTmp = new List<Color>(colors);
        // List<CardBehavior> deckTmp = new List<CardBehavior>(deck);

        // // Tant qu'il reste des cartes a associer
        // while (deckTmp.Count > 0)
        // {
        //     // Tire une couleur au hasard et la retire de la liste temporaire
        //     int colorIndex = Random.Range(0, colorsTmp.Count);
        //     Color rngColor = colorsTmp[colorIndex];
        //     colorsTmp.RemoveAt(colorIndex);

        //     // Tirage des 2 cartes aleatoirement et les retirer du deck temporaire
        //     int firstCardIndex = Random.Range(0, deckTmp.Count);
        //     CardBehavior firstCard = deckTmp[firstCardIndex];
        //     deckTmp.RemoveAt(firstCardIndex);

        //     int secondCardIndex = Random.Range(0, deckTmp.Count);
        //     CardBehavior secondCard = deckTmp[secondCardIndex];
        //     deckTmp.RemoveAt(secondCardIndex);

        //     // Attribution de la couleurs aux 2 cartes
        //     firstCard.Initialize(rngColor, firstCardIndex, this);
        //     secondCard.Initialize(rngColor, secondCardIndex, this);
        // }



        //Correction
        // int colorIndex;
        // for (int index = 0; index < deck.Count; index++)
        // {
        //     colorIndex = Random.Range(0, colors.Length);
        //     deck[index].Initialize(colors[colorIndex], colorIndex, this);
        // }

        // Correction pair de couleurs

        for (int _ = 0; _ < deck.Count / 2; _++)
        {
            colorIndex = Random.Range(0, colors.Length);

            while (colorsAlreadyInGame.Contains(colorIndex))
            {
                colorIndex = Random.Range(0, colors.Length);
            }

            colorsAlreadyInGame.Add(colorIndex);

            for (int __ = 0; __ < 2; __++)
            {
                cardIndex = Random.Range(0, cards.Count);
                cards[cardIndex].Initialize(colors[colorIndex], colorIndex, this);
                cards.RemoveAt(cardIndex);
            }

        }

    }


    public void CardIsClicked(CardBehavior card)
    {
        if (card.IsFaceUp) return;
        // Tout les réactions des cartes faces visible
        card.FaceUp();

        // Surcharge d'opérateur sur les objets d'Unity ne pas utiliser is null
        // Si 'jai une carte mémorisée
        if (memoCard != null)
        {
            // si la carte memeo est la meme que la carte courante
            if (card.IndexColor != memoCard.IndexColor)
            {
                memoCard.FaceDown(delayBeforeFaceDown);
                card.FaceDown(delayBeforeFaceDown);
            }
            else
            {
                combinasonFound++;
                if (combinasonFound == deck.Count / 2)
                {
                    victoryManager.LaunchVictory();
                    //SceneManager.LoadScene("Victory Scene");
                    //StartCoroutine(winManager.ChangeScene(2));
                }

            }

            // Remet la carte memo a null
            memoCard = null;
        }
        else
        {
            memoCard = card;
        }
    }

    private IEnumerator ChangeScene(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Victory Scene");
    }
}