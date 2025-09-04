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

    /// <summary>
    /// Mémorisation du scale précédent
    /// </summary>
    private Vector3 memoScale;
    private Color color;
    private int indexColor;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <param name="indexColor">reference de la couleur pour le manager</param>
    public void Initialize(Color color, int indexColor, CardsManager manager)
    {
        this.color = color;
        this.indexColor = indexColor;
        this.manager = manager;
        
        /// Temporary: it will be deleted when we will have finish the initialization.
        ChangColor(color);
    }
    private void ChangColor(Color color)
    {
        /// renderer est responsable du rendu a la caméra et a acces au material
        GetComponent<Renderer>().material.color = color;
    }
}
