using EliteMMO.Scripted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteMMO.Scripted.Views
{
    public interface IScriptedView
    {
        void Update(IScriptedModel model);
    }
}
