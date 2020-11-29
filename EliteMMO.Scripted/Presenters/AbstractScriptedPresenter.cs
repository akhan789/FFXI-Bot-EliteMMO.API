using EliteMMO.Scripted.Models;
using EliteMMO.Scripted.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteMMO.Scripted.Presenters
{
    public abstract class AbstractScriptedPresenter : IScriptedPresenter
    {
        protected IScriptedModel model;
        protected IScriptedView view;

        public AbstractScriptedPresenter(IScriptedModel model, IScriptedView view)
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
