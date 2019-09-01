using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controllers;

namespace Assets.Scripts.BaseScripts
{
    class MainScript: MonoBehaviour
    {
        #region Список контроллеров

        //Контроллер Анимаций меню
        public MenuAnimationController menuAnimController { get; private set; }

        //Контроллер Создания примитивов
        public PrimitiveInstantiateController primInstController { get; private set; }

        //Контроллер Счета-Очков
        public ScoreController scoreController { get; private set; }

        //Контроллер Паузы
        public PauseController pauseController { get; private set; }

        //Контроллер Рестарт
        public RestartController restartController { get; private set; }

        private List<BaseController> AllControllers = new List<BaseController>(5);

        #endregion

        public static MainScript GetMainScript { get; private set; }

        private void Awake()
        {
            GetMainScript = this;
            
            //Ссылка на объект Меню UI
            GameObject menuPanel = GameObject.FindGameObjectWithTag("MenuPanel");

            //Ссылка на объект Счета-Очков UI
            GameObject scoreObj = GameObject.FindGameObjectWithTag("ScoreObject");

            //Ссылка на объект Рестарт UI
            GameObject restartObj = GameObject.FindGameObjectWithTag("RestartObject");

            //Ссылка на объект Таймер UI
            GameObject timerObj = GameObject.FindGameObjectWithTag("TimerObject");

            //Создаем списки положительных и отрицательных объектов, загружаем префабы
            List<GameObject> PositiveObjects = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/PosPrefabs"));
            List<GameObject> NegativeObjects = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/NegPrefabs"));        

            //Создаем контроллеры
            menuAnimController = new MenuAnimationController(menuPanel);
            primInstController = new PrimitiveInstantiateController(PositiveObjects, NegativeObjects, timerObj);
            scoreController = new ScoreController(scoreObj);
            pauseController = new PauseController();
            restartController = new RestartController(restartObj);

            #region Добавляем контроллеры в коллекцию

            AllControllers.Add(menuAnimController);
            AllControllers.Add(primInstController);
            AllControllers.Add(scoreController);
            AllControllers.Add(pauseController);
            AllControllers.Add(restartController);

            #endregion
        }

        private void Update()
        {
            //Запускаем Update каждого контроллера
            foreach (var Controller in AllControllers)
            {
                Controller.ControllerUpdate();
            }
        }
    }
}
