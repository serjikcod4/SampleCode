using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.BaseScripts;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers
{
    public class PrimitiveInstantiateController : BaseController
    {
        //Ширина и высота разрешения экрана
        private int width;
        private int height;
        private int minWidth;
        private int minHeight;
        private int maxWidth;
        private int maxHeight;
        private int indentFromScreenBound = 100;
        private int indentFromTopHeightBound = 400;

        //Список позитивных и негативных объектов
        private List<GameObject> PositiveObjects;
        private List<GameObject> NegativeObjects;

        //Ссылка на UI Таймер
        private GameObject timerObject;
        private Text timerText;

        //Счетчики для создания примитивов и отсчета 60сек
        private float timer = 60f;
        private float positiveTimer = 0.5f;
        private float negativeTimer = 1f;
        private float timerCount = 60f;
        private float posTimerCount = 0f;
        private float negTimerCount = 0f;

        /// <summary>
        /// Конструктор
        /// </summary>
        public PrimitiveInstantiateController(List<GameObject> positiveObjects, List<GameObject> negativeObjects, GameObject timerObject)
        {
            this.timerObject = timerObject;
            timerText = this.timerObject.GetComponent<Text>();
            width = Screen.width;
            height = Screen.height;
            PositiveObjects = positiveObjects;
            NegativeObjects = negativeObjects;
            minHeight = indentFromScreenBound;
            maxHeight = height - indentFromTopHeightBound;
            minWidth = indentFromScreenBound;
            maxWidth = width - indentFromScreenBound;
        }

        public override void ControllerUpdate()
        {     
            timerCount -= Time.deltaTime;
            posTimerCount += Time.deltaTime;
            negTimerCount += Time.deltaTime;
            timerText.text = timerCount.ToString("#");

            //Создание позитив объекта
            if (posTimerCount >= positiveTimer)
            {
                //Преобразуем размер экрана в глобальные координаты + рандомная позиция
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight),0));
                Object.Instantiate(PositiveObjects[Random.Range(0, 6)], new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                posTimerCount = 0f;
            }

            //Создание негатив объекта
            if (negTimerCount >= negativeTimer)
            {
                //Преобразуем размер экрана в глобальные координаты + рандомная позиция
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight),0));
                Object.Instantiate(NegativeObjects[Random.Range(0, 6)], new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                negTimerCount = 0f;
            }

            //Если закончилось время 60сек
            if (timerCount <= 0)
            {
                MainScript.GetMainScript.pauseController.Pause();
                MainScript.GetMainScript.restartController.restartAnimator.SetBool("showRestartObject", true);
                MainScript.GetMainScript.restartController.restartAnimator.SetBool("reverseRestartObject", false);              
            }
        }

        //Сбрасывание всех таймеров
        public void ResetTimers()
        {
            timer = 60f;
            positiveTimer = 0.5f;
            negativeTimer = 1f;
            timerCount = 60f;
            posTimerCount = 0f;
            negTimerCount = 0f;
        }
    }
}
