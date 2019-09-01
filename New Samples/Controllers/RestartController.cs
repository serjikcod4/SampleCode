using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.BaseScripts;

namespace Assets.Scripts.Controllers
{
    public class RestartController : BaseController
    {
        //Ссылка на Аниматор
        public Animator restartAnimator { get; private set; }

        //Ссылка на позитивные объекты
        private GameObject[] positiveObjects;

        //Ссылка на негативные объекты
        private GameObject[] negativeObjects;

        //Ссылка на UI Рестарт объект
        private GameObject restartObject;

        //Ссылка на UI кнопку Рестарт
        private Button restartButton;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="restartObject">Ссылка на UI Рестарт объект</param>
        public RestartController(GameObject restartObject)
        {
            this.restartObject = restartObject;
            restartButton = this.restartObject.GetComponent<Button>();
            restartAnimator = this.restartObject.GetComponent<Animator>();
            restartButton.onClick.AddListener(RestartScene);
            restartButton.onClick.AddListener(MainScript.GetMainScript.pauseController.Unpause);
        }

        public override void ControllerUpdate()
        {
            
        }

        public void RestartScene()
        {
            //Находим все позитивные и негативные объекты на сцене
            positiveObjects = GameObject.FindGameObjectsWithTag("PositiveObject");
            negativeObjects = GameObject.FindGameObjectsWithTag("NegativeObject");
            //Удаляем позитивные
            if (positiveObjects != null)
            {
                foreach (var obj in positiveObjects)
                {
                    obj.GetComponent<PositiveModel>().DestroyObject();
                }
            }
            //Удаляем негативные
            if (negativeObjects != null)
            {
                foreach (var obj in negativeObjects)
                {
                    obj.GetComponent<NegativeModel>().DestroyObject();
                }
            }     

            //Сбрасываем Счет-Очки
            MainScript.GetMainScript.scoreController.ResetScore();

            //Сбрасываем все таймера
            MainScript.GetMainScript.primInstController.ResetTimers();

            //Анимируем объект Рестарт на реверс
            restartAnimator.SetBool("reverseRestartObject", true);

            //Сбрасываем все на состояния анимаций на false           
            restartAnimator.SetBool("showRestartObject", false);
        }
    }
}

