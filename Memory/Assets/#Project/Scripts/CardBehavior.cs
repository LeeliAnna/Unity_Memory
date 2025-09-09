using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Empeche de retirer le renderer d'un composant qui possède ce script, et empeche également de retirer le renderer
/// Il faut absolument qu'il y ai un renderer sur l'object qui va utiliser ce script
/// Evite de devoir faire une verification quand un veut modifier le renderer qu'il existe bien. 
/// </summary>
[RequireComponent(typeof(Renderer))]

public class CardBehavior : MonoBehaviour
{
    /// <summary>
    /// Donner une taille quand on focus une carte
    /// </summary>
    // Vector3.one = (1,1,1)
    [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.5f;
    [SerializeField] private float changeColorTime = 1f;

    /// <summary>
    /// Mémorisation du scale précédent
    /// </summary>
    private Vector3 memoScale;
    private Color color;
    [SerializeField] private Color baseColor = Color.black;
    public int IndexColor { get; private set; }
    public bool IsFaceUp { get; private set; } = false;
    private CardsManager manager;

    private void OnMouseEnter()
    {
        memoScale = transform.localScale;
        transform.localScale = scaleOnFocus;
    }

    private void OnMouseExit()
    {
        transform.localScale = memoScale;
    }

    // Réagit uniqement lorsqu'on relache le click cela permet de verifier la différence d'etat entre le click et son relachement
    private void OnMouseDown()
    {
        manager.CardIsClicked(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <param name="indexColor">reference de la couleur pour le manager</param>
    public void Initialize(Color color, int indexColor, CardsManager manager)
    {
        this.color = color;
        IndexColor = indexColor;
        this.manager = manager;

        ChangeColor(baseColor);
        IsFaceUp = false;
    }
    private void ChangeColor(Color color)
    {
        /// renderer est responsable du rendu a la caméra et a acces au material
        GetComponent<Renderer>().material.color = color;
    }

    // change la couleur de base en couleur attribuée quand la carte est retournée
    public void FaceUp()
    {
        StartCoroutine(ChangeColorWithLerp(color));
        IsFaceUp = true;
    }

    // remet le couleur de base quand la carte est vas non visible
    public void FaceDown()
    {
        StartCoroutine(ChangeColorWithLerp(baseColor));
        IsFaceUp = false;
    }

    private IEnumerator ChangeColorWithLerp(Color color)
    {
        float chrono = 0f;
        Color startColor = GetComponent<Renderer>().material.color;

        while (chrono < changeColorTime)
        {
            // ajoute le temps passer depuis le debut de la coroutine
            chrono += Time.deltaTime;

            // Avec Chrono et changeColorTime on a ce qu'il nous faut pour utilsier Lerp
            // Color c = Color.Lerp(startColor, color, chrono / changeColorTime);
            // ChangeColor(c);

            ChangeColor(Color.Lerp(startColor, color, chrono / changeColorTime));
            yield return new WaitForEndOfFrame(); // => yield return null
        }

        // temporise s'il y a eu un gros lag
        ChangeColor(color);
    }


}
