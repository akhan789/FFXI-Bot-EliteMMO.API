using EliteMMO.Scripted.Models;
using EliteMMO.Scripted.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteMMO.Scripted.Controller
{
    public interface IScriptedController
    {
        void SetModel(IScriptedModel model);
        void SetView(IScriptedView view);
    }
}
