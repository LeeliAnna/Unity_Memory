using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    List<CardBehavior> deck;
    Color[] colors;
    public void Initialize(List<CardBehavior> deck, Color[] colors)
    {
        this.colors = colors;
        this.deck = deck;

        /// Exercice
        //Copie du tableau de couleurs en une liste et du deck
        List<Color> colorsTmp = new List<Color>(colors);
        List<CardBehavior> deckTmp = new List<CardBehavior>(deck);

        // Tant qu'il reste des cartes à associer
        while (deckTmp.Count > 0)
        {
            // Tire une couleur au hasard et la retire de la liste temporaire
            int colorIndex = Random.Range(0, colorsTmp.Count);
            Color rngColor = colorsTmp[colorIndex];
            colorsTmp.RemoveAt(colorIndex);

            // Tirage des 2 cartes aléatoirement et les retirer du deck temporaire
            int firstCardIndex = Random.Range(0, deckTmp.Count);
            CardBehavior firstCard = deckTmp[firstCardIndex];
            deckTmp.RemoveAt(firstCardIndex);

            int secondCardIndex = Random.Range(0, deckTmp.Count);
            CardBehavior secondCard = deckTmp[secondCardIndex];
            deckTmp.RemoveAt(secondCardIndex);

            // Attribution de la couleurs aux 2 cartes
            firstCard.Initialize(rngColor, firstCardIndex, this);
            secondCard.Initialize(rngColor, secondCardIndex, this);
        }



        //Correction
        // int colorIndex;
        // for (int index = 0; index < deck.Count; index++)
        // {
        //     colorIndex = Random.Range(0, colors.Length);
        //     deck[index].Initialize(colors[colorIndex], colorIndex, this);
        // }
    }
}