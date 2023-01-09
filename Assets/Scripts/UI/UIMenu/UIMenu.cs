using System.Collections;
using UnityEngine;

public abstract class UIMenu : MonoBehaviour
{
    public abstract IEnumerator Open();
    public abstract IEnumerator Close();

    public bool IsAnimated { get; protected set; }
}