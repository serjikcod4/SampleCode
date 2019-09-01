using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.BaseScripts;
using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{
    public class ScoreController : BaseController
    {
        //Ссылка на UI объект Счета
        private GameObject scoreObj;
        private Text scoreText;

        //Ссылка на модель Счета
        private ScoreModel scoreModel;

        /// <summary>
        /// Конструктов
        /// </summary>
        /// <param name="scoreObj"></param>
        public ScoreController(GameObject scoreObj)
        {
            scoreModel = new ScoreModel();
            this.scoreObj = scoreObj;
            scoreText = scoreObj.GetComponent<Text>();
        }

        public override void ControllerUpdate()
        {
            
        }

        //Добавление очков к счету + отображение на UI
        public void AddPointToScore(int point)
        {
            scoreModel.score += point;
            scoreText.text = scoreModel.score.ToString();
        }

        //Сброс очков и UI
        public void ResetScore()
        {
            scoreModel.score = 0;
            scoreText.text = null;
        }
    }
}

