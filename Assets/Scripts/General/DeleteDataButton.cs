using UnityEngine;

public class DeleteDataButton : MonoBehaviour
{
    public void DeleteSavedData() => SaveSystem.Delete();
}
