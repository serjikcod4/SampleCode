using UnityEngine;
using Assets.Scripts.BaseScripts;

namespace Assets.Scripts.Controllers
{
    public class PauseController : BaseController
    {
        public override void ControllerUpdate()
        {

        }
        
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}

