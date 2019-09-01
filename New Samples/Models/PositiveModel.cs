using UnityEngine;
using Assets.Scripts.BaseScripts;

//Скрипт позитивной модели примитива
public class PositiveModel : MonoBehaviour
{
    //Очки за примитив
    private int onePoint = 1;
    private int twoPoints = 2;

    //При клике на объект добавляем одно очко и уничтожаем этот объект
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
