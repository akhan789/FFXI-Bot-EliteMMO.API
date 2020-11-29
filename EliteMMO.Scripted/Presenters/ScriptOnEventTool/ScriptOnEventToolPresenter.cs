using EliteMMO.Scripted.Models.ScriptOnEventTool;
using EliteMMO.Scripted.Views.ScriptOnEventTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.ListView;

namespace EliteMMO.Scripted.Presenters.ScriptOnEventTool
{
    public class ScriptOnEventToolPresenter : AbstractScriptedPresenter, IScriptOnEventToolPresenter
    {
        private IScriptOnEventToolView scriptOnEventToolView;
        private IScriptOnEventToolModel scriptOnEventToolModel;

        public ScriptOnEventToolPresenter(IScriptOnEventToolModel model, IScriptOnEventToolView view) : base(model, view)
        {
            scriptOnEventToolView  = (IScriptOnEventToolView)view;
            scriptOnEventToolModel = (IScriptOnEventToolModel)model;
        }

        public void RequestStartScript()
        {
            if (model is IScriptOnEventToolModel)
            {
                ((IScriptOnEventToolModel)model).StartBot();
                if (view != null)
                {
                    SetView(ScriptOnEventToolModel.Function.START_BOT);
                }
            }
        }

        public void RequestStopScript()
        {
            if (model is IScriptOnEventToolModel)
            {
                ((IScriptOnEventToolModel)model).StopBot();
                if (view != null)
                {
                    SetView(ScriptOnEventToolModel.Function.STOP_BOT);
                }
            }
        }
        public void CreateSaveEvent()
        {
            if (model is IScriptOnEventToolModel)
            {
                if (view is IScriptOnEventToolView)
                {
                    IScriptOnEventToolView onEventToolView = (IScriptOnEventToolView)view;
                    IScriptOnEventToolModel onEventToolModel = (IScriptOnEventToolModel)model;
                    onEventToolModel.CurrentEventsListItems = onEventToolView.EventsList.Items;
                    if (!string.IsNullOrEmpty(onEventToolView.ChatEventText) || !string.IsNullOrEmpty(onEventToolView.ExecuteCommandText))
                    {
                        if (onEventToolView.EventsList.SelectedItems.Count > 0)
                        {
                            ListViewItem selected = onEventToolView.EventsList.SelectedItems[0];
                            selected.SubItems[0].Text = onEventToolView.ChatEventText;
                            selected.SubItems[1].Text = onEventToolView.ExecuteCommandText;
                            selected.SubItems[2].Text = onEventToolView.ChatTypeComboText;
                            selected.SubItems[3].Text = onEventToolView.UseRegexChecked.ToString();
                        }
                        else
                        {
                            onEventToolModel.CurrentEventsListItems.Add(new ListViewItem(new string[] {
                                onEventToolView.ChatEventText, onEventToolView.ExecuteCommandText,
                                onEventToolView.ChatTypeComboText, onEventToolView.UseRegexChecked.ToString()
                            }));
                        }
                        onEventToolModel.CreateOrSaveEvent();
                    }
                    SetView(ScriptOnEventToolModel.Function.CREATE_OR_SAVE_EVENT);
                }
            }
        }

        public void SetView(ScriptOnEventToolModel.Function function)
        {
            if (view is IScriptOnEventToolView && model is IScriptOnEventToolModel)
            {
                IScriptOnEventToolView onEventToolView = (IScriptOnEventToolView)view;
                IScriptOnEventToolModel onEventToolModel = (IScriptOnEventToolModel)model;
                switch (function)
                {
                    case ScriptOnEventToolModel.Function.START_BOT:
                        onEventToolView.EnableStartScriptToolStripMenuItem(false);
                        onEventToolView.EnableStopScriptToolStripMenuItem(true);
                        break;
                    case ScriptOnEventToolModel.Function.STOP_BOT:
                        onEventToolView.EnableStartScriptToolStripMenuItem(true);
                        onEventToolView.EnableStopScriptToolStripMenuItem(false);
                        break;
                    case ScriptOnEventToolModel.Function.CREATE_OR_SAVE_EVENT:
                        if (onEventToolView.EnableSaveOEToolStripMenuItem == false)
                        {
                            onEventToolView.EnableSaveOEToolStripMenuItem = true;
                        }
                        if (onEventToolView.EnableRemoveCheckedOEToolStripMenuItem == false)
                        {
                            onEventToolView.EnableRemoveCheckedOEToolStripMenuItem = true;
                        }
                        if (onEventToolView.EnableEditSelectedToolStripMenuItem == false)
                        {
                            onEventToolView.EnableEditSelectedToolStripMenuItem = true;
                        }

                        onEventToolView.ChatEventText = "";
                        onEventToolView.ExecuteCommandText = "";
                        break;
                    default:
                        break;
                }
                onEventToolModel.NotifyObservers();
            }
        }
    }
}
