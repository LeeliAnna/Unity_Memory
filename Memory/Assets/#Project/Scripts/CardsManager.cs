using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    List<CardBehavior> deck;
    Color[] colors;
    public void Initialize(List<CardBehavior> deck, Color[] colors)
    {
        this.colors = colors;
        this.deck = deck;

        // Pour faire 2 cartes faire +2? ou pop?
        /// Exercice
        int indexColor;
        //Copie du tableau de couleurs en une liste
        List<Color> colorsTmp = new List<Color>();
        for (int i = 0; i < colors.Length; i++)
        {
            colorsTmp.Add(colors[i]);
            colorsTmp.Add(colors[i]);
        }


        for (int i = 0; i < deck.Count; i++)
        {
            // selectionner 2 cartes au hasard et attribuer la couleur
            
            indexColor = Random.Range(0, colors.Length);
            deck[i].Initialize(colors[indexColor], indexColor, this);
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
