using UnityEditor.Media;
using UnityEngine;

//[CreateAssetMenu(fileName ="BaseCard")]
public abstract class BaseCardSO : ScriptableObject
{
    public string cardName;
    public string explanation;
    public GameObject baseCard;
    public Material cardMaterial;
  
}
