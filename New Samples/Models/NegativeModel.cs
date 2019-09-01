using UnityEngine;
using Assets.Scripts.BaseScripts;

//Скрипт негативной модели
public class NegativeModel : MonoBehaviour
{
    //Очки за объект
    private int onePoint = -1;
    private int twoPoints = -2;

    //При клике на объект снимаем одно очко и уничтожаем этот объект
    private void OnMouseDown()
    {
        MainScript.GetMainScript.scoreController.AddPointToScore(onePoint);
        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
