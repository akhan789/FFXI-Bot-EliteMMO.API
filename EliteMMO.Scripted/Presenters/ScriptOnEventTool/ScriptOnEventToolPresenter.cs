using EliteMMO.Scripted.Models.ScriptOnEventTool;
using EliteMMO.Scripted.Views.ScriptOnEventTool;
using System;
using System.Collections;
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
            scriptOnEventToolView = (IScriptOnEventToolView)view;
            scriptOnEventToolModel = (IScriptOnEventToolModel)model;
        }
        public void StartScript()
        {
            scriptOnEventToolModel.StartBot();
            scriptOnEventToolView.EnableStartScriptToolStripMenuItem = false;
            scriptOnEventToolView.EnableStopScriptToolStripMenuItem = true;
        }
        public void StopScript()
        {
            scriptOnEventToolModel.StopBot();
            scriptOnEventToolView.EnableStartScriptToolStripMenuItem = true;
            scriptOnEventToolView.EnableStopScriptToolStripMenuItem = false;
        }
        public void CreateOrSaveEvent()
        {
            if (!string.IsNullOrEmpty(scriptOnEventToolView.ChatEventText) || !string.IsNullOrEmpty(scriptOnEventToolView.ExecuteCommandText))
            {
                IList selectedItems;
                if ((selectedItems = scriptOnEventToolView.SelectedItems).Count > 0)
                {
                    scriptOnEventToolView.GetEventItemsSubItemsSetText(selectedItems[0], 0, scriptOnEventToolView.ChatEventText);
                    scriptOnEventToolView.GetEventItemsSubItemsSetText(selectedItems[0], 1, scriptOnEventToolView.ExecuteCommandText);
                    scriptOnEventToolView.GetEventItemsSubItemsSetText(selectedItems[0], 2, scriptOnEventToolView.ChatTypeComboText);
                    scriptOnEventToolView.GetEventItemsSubItemsSetText(selectedItems[0], 3, scriptOnEventToolView.UseRegexChecked.ToString());
                }
                else
                {
                    scriptOnEventToolView.CurrentEventsListItems.Add(new string[] {
                        scriptOnEventToolView.ChatEventText, scriptOnEventToolView.ExecuteCommandText,
                        scriptOnEventToolView.ChatTypeComboText, scriptOnEventToolView.UseRegexChecked.ToString()
                    });
                }

                if (scriptOnEventToolView.EnableSaveOEToolStripMenuItem == false)
                {
                    scriptOnEventToolView.EnableSaveOEToolStripMenuItem = true;
                }
                if (scriptOnEventToolView.EnableRemoveCheckedOEToolStripMenuItem == false)
                {
                    scriptOnEventToolView.EnableRemoveCheckedOEToolStripMenuItem = true;
                }
                if (scriptOnEventToolView.EnableEditSelectedToolStripMenuItem == false)
                {
                    scriptOnEventToolView.EnableEditSelectedToolStripMenuItem = true;
                }

                scriptOnEventToolView.ChatEventText = "";
                scriptOnEventToolView.ExecuteCommandText = "";

                IList<string> chatEventTexts = new List<string>();
                IList<string> eventCommandTexts = new List<string>();
                IList<string> chatTypeXTexts = new List<string>();
                IList<string> isRegExTexts = new List<string>();
                IList<bool> checkedItem = new List<bool>();
                for (int x = 0; x < scriptOnEventToolView.CurrentEventsListItems.Count; x++)
                {
                    chatEventTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 0).ToString());
                    eventCommandTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 1).ToString());
                    chatTypeXTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 2).ToString());
                    isRegExTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 3).ToString());
                    checkedItem.Add(scriptOnEventToolView.IsEventsListItemChecked(x));
                }
                scriptOnEventToolModel.CreateOrSaveEvent(scriptOnEventToolView.CurrentEventsListItems, chatEventTexts, eventCommandTexts, chatTypeXTexts, isRegExTexts, checkedItem);
            }
        }
        public void LoadOnEventsFile()
        {
            try
            {
                scriptOnEventToolModel.LoadOnEventsFile();
                if (scriptOnEventToolView.EnableSaveOEToolStripMenuItem == false)
                {
                    scriptOnEventToolView.EnableSaveOEToolStripMenuItem = true;
                }

                if (scriptOnEventToolView.EnableRemoveCheckedOEToolStripMenuItem == false)
                {
                    scriptOnEventToolView.EnableRemoveCheckedOEToolStripMenuItem = true;
                }

                if (scriptOnEventToolView.EnableEditSelectedToolStripMenuItem == false)
                {
                    scriptOnEventToolView.EnableEditSelectedToolStripMenuItem = true;
                }
            }
            catch (Exception e)
            {
                scriptOnEventToolView.ShowMessageBox("Failed to load the OnEvents file. Please try again.\n" + e.Message);
                throw;
            }
        }

        public void SaveOnEventsFile()
        {
            IList<string> chatEventTexts = new List<string>();
            IList<string> eventCommandTexts = new List<string>();
            IList<string> chatTypeXTexts = new List<string>();
            IList<string> isRegExTexts = new List<string>();
            IList<bool> checkedItem = new List<bool>();
            for (int x = 0; x < scriptOnEventToolView.CurrentEventsListItems.Count; x++)
            {
                chatEventTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 0).ToString());
                eventCommandTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 1).ToString());
                chatTypeXTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 2).ToString());
                isRegExTexts.Add(scriptOnEventToolView.GetEventItemsSubItemsGetText(x, 3).ToString());
                checkedItem.Add(scriptOnEventToolView.IsEventsListItemChecked(x));
            }
            scriptOnEventToolModel.SaveOnEventsFile(scriptOnEventToolView.CurrentEventsListItems, chatEventTexts, eventCommandTexts, chatTypeXTexts, isRegExTexts, checkedItem);
        }

        public void EditSelectedItem()
        {
            scriptOnEventToolView.ChatEventText = scriptOnEventToolView.GetSelectedEventItemsSubItemsGetText(0, 0);
            scriptOnEventToolView.ExecuteCommandText = scriptOnEventToolView.GetSelectedEventItemsSubItemsGetText(0, 1);
            scriptOnEventToolView.ChatTypeComboText = scriptOnEventToolView.GetSelectedEventItemsSubItemsGetText(0, 2);

            if (scriptOnEventToolView.GetSelectedEventItemsSubItemsGetText(0, 3).ToString() == "False")
            {
                scriptOnEventToolView.UseRegexChecked = false;
            }
            else
            {
                scriptOnEventToolView.UseRegexChecked = true;
            }
        }

        public void RemoveSelectedItems()
        {
            if (scriptOnEventToolView.SelectedItems.Count <= 0)
            {
                return;
            }

            foreach (object selected in scriptOnEventToolView.SelectedItems)
            {
                scriptOnEventToolView.removeEventsListItem(selected);
            }

            if (scriptOnEventToolView.CurrentEventsListItems.Count == 0)
            {
                scriptOnEventToolView.EnableSaveOEToolStripMenuItem = false;
                scriptOnEventToolView.EnableRemoveCheckedOEToolStripMenuItem = false;
                scriptOnEventToolView.EnableEditSelectedToolStripMenuItem = false;
            }
        }
        public void RemoveCheckedItems()
        {
            foreach (object item in scriptOnEventToolView.CheckedItems)
            {
                scriptOnEventToolView.removeEventsListItem(item);
            }

            if (scriptOnEventToolView.CurrentEventsListItems.Count == 0)
            {
                if (scriptOnEventToolView.EnableSaveOEToolStripMenuItem == true)
                {
                    scriptOnEventToolView.EnableSaveOEToolStripMenuItem = false;
                }

                if (scriptOnEventToolView.EnableRemoveCheckedOEToolStripMenuItem == true)
                {
                    scriptOnEventToolView.EnableRemoveCheckedOEToolStripMenuItem = false;
                }

                if (scriptOnEventToolView.EnableEditSelectedToolStripMenuItem == true)
                {
                    scriptOnEventToolView.EnableEditSelectedToolStripMenuItem = false;
                }
            }
        }
    }
}
