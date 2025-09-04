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
        int indexColor;
        //Copie du tableau de couleurs en une liste
        List<Color> colorsTmp = new List<Color>();
        for (int i = 0; i < colors.Length; i++)
        {
            colorsTmp.Add(colors[i]);
        }

        // Création d'une lilste contenant les cartes dont la couleur a ete modifiée
        List<CardBehavior> cardModified = new List<CardBehavior>();
        //Initilisation variable pour les cartes random
        int firstCard;
        int secondCard;

        // Boucle sur le tableau d'origine contenant toutes les cartes
        for (int i = 0; i < deck.Count; i++)
        { 
            // Selectionne une 1ere carte au hasard
            firstCard = Random.Range(0, deck.Count);
            do
            {
                // selectionne une dexième et verifier qu'elle sont différentes
                secondCard = Random.Range(0, deck.Count);
            }
            while (firstCard == secondCard);
            Debug.Log($"First card : {firstCard}");
            Debug.Log($"Second card : {secondCard}");

            // Si ma liste de carte modifier ne contient pas les cartes selectionnées
            if (!cardModified.Contains(deck[firstCard]) && !cardModified.Contains(deck[secondCard]))
            {
                Debug.Log("I modified cards");
                // selectionne une couleur aléatoirement 
                indexColor = Random.Range(0, colorsTmp.Count);
                // Applique la couleurs aux cartes
                deck[firstCard].Initialize(colors[indexColor], indexColor, this);
                deck[secondCard].Initialize(colors[indexColor], indexColor, this);
                // Ajoute les carde dans la liste de cartes modifier
                Debug.Log("Ajout des cartes dans la liste de modification");
                cardModified.Add(deck[firstCard]);
                cardModified.Add(deck[secondCard]);
                // Supprime la couleur de la liste temporaire
                Debug.Log("Suppression de la couleur ajoutée");
                colorsTmp.RemoveAt(indexColor);
            }

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