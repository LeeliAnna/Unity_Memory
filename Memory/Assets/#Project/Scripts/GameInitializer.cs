using Unity.Mathematics;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // le cube dans la scène représente 1
    const float CARD_SIZE = 1.0f;
    [SerializeField] private int rows = 2;
    [SerializeField] private int columns = 3;
    // Le gap permet d'avoir un espace entre chaque card qui vaut la moitier de la taille de la carte
    [SerializeField] private float gap = 0.5f;
    [SerializeField] private GameObject cardPrefab;

    private void Start()
    {
        // verification que le nombre total de cartes sera bien un nombre paire.
        if ((rows * columns) % 2 != 0)
        {
            Debug.LogError("The cards numbers need to be even.");
            return;
        }
        ObjectsCreation();
    }

    private void ObjectsCreation()
    {
        //// Exercice 
        // Vector3 startPos = transform.position;

        // float newGap = gap + CARD_SIZE;
        // for (int col = 0; col < columns; col++) 
        // {
        //     for (int row = 0; row < rows; row++)
        //     {
        //         Vector3 spawnPos = new Vector3(startPos.x + newGap * row, startPos.y, startPos.z + newGap * col);
        //         Instantiate(cardPrefab, spawnPos, Quaternion.identity);
        //     }
        // }

        //// Solution
        Vector3 position;
        /// ici on fait le calcul de position avec la boucle for
        for (float x = 0f; x < columns * (CARD_SIZE + gap); x += CARD_SIZE + gap)
        {
            for (float z = 0f; z < rows * (CARD_SIZE + gap); z += CARD_SIZE + gap)
            {
                // Ici on modifie le vecteur avec right qui fait le x (1,0,0) et forward qui représente le z (0,0,1)
                position = transform.position + Vector3.right * x + Vector3.forward * z;
                Instantiate(cardPrefab, position, Quaternion.identity);

            }

        }
        // ici le calcul doit etre fait dans la boucle plus gourmand en perf a ne pas faire si la fonction est applée dans un update
        //for (float x = 0; x < columns; x++)
        //{
            //x *= CARD_SIZE + gap;//
         //}
    }
}
