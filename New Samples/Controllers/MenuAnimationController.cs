using Assets.Scripts.BaseScripts;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class MenuAnimationController : BaseController
    {
        //Ссылка на аниматор Меню
        private Animator menuAnimator;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="menuPanel">Ссылка на объект Меню</param>
        public MenuAnimationController(GameObject menuPanel)
        {
            menuAnimator = menuPanel.GetComponent<Animator>();
        }

        public override void ControllerUpdate()
        {
            
        }

        /// <summary>
        /// Показываем меню
        /// </summary>
        public void ShowMenu()
        {
            menuAnimator.SetBool("showMenu", true);
        }
    }
}

