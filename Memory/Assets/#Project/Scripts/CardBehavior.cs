using UnityEngine;

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
    [SerializeField] private Vector3 memoScale;

    private void OnMouseEnter()
    {
        memoScale = transform.localScale;
        transform.localScale = scaleOnFocus;
    }

    private void OnMouseExit()
    {
        transform.localScale = memoScale;
    }
}
