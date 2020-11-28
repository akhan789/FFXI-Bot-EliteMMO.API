using EliteMMO.Scripted.Models;
using EliteMMO.Scripted.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteMMO.Scripted.Controller
{
    public abstract class AbstractScriptedController : IScriptedController
    {
        protected IScriptedModel model;
        protected IScriptedView view;

        public AbstractScriptedController()
        {
        }

        public AbstractScriptedController(IScriptedModel model, IScriptedView view)
        {
            this.model = model;
        }
        public void SetModel(IScriptedModel model)
        {
            this.model = model;
        }
        public void SetView(IScriptedView view)
        {
            this.view = view;
        }
    }
}
