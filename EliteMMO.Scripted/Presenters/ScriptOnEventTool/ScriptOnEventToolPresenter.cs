using EliteMMO.Scripted.Models.ScriptOnEventTool;
using EliteMMO.Scripted.Views.ScriptOnEventTool;
using System;
using System.Collections;
using System.Collections.Generic;
using static EliteMMO.Scripted.Models.ScriptOnEventTool.ScriptOnEventToolModel;

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
                string openFilename;
                if ((openFilename = scriptOnEventToolView.ShowFileDialog(false, "Select OnEvents File To Load", "OnEvent File (*.xml)|*.xml|OnEvent File (*.oef)|*.oef", 1, true)) != null)
                {
                    scriptOnEventToolView.CurrentEventsListItems.Clear();
                    scriptOnEventToolModel.FileXML = openFilename;
                    IList<EventElement> eventsList = scriptOnEventToolModel.LoadOnEventsFile();
                    for (int x = 0; x < eventsList.Count; x++)
                    {
                        scriptOnEventToolView.CurrentEventsListItemAddItem(eventsList[x].Item);
                        scriptOnEventToolView.CurrentEventsListItemAddItem(eventsList[x + 1].Item);
                        scriptOnEventToolView.SetEventsListItemChecked(x, eventsList[x].Checked);
                        if (eventsList[x].SubItems?.Count > 0)
                        {
                            for (int y = 0; y < eventsList[x].SubItems.Count; y++)
                            {
                                scriptOnEventToolView.CurrentEventsListItemAddSubItem(x, eventsList[x].SubItems[y]);
                            }
                        }
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
            try
            {
                string saveFilename;
                if ((saveFilename = scriptOnEventToolView.ShowFileDialog(true, "Save OnEvents File", "OnEvent File (*.xml)|*.xml", 0, true)) != null)
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
                    scriptOnEventToolModel.SaveOnEventsFile(saveFilename, scriptOnEventToolView.CurrentEventsListItems, chatEventTexts, eventCommandTexts, chatTypeXTexts, isRegExTexts, checkedItem);
                }
            }
            catch (Exception e)
            {
                scriptOnEventToolView.ShowMessageBox("Failed to save OnEvents file. Please try another location.\n" + e.Message);
                throw;
            }
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
                scriptOnEventToolView.RemoveEventsListItem(selected);
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
                scriptOnEventToolView.RemoveEventsListItem(item);
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
        public void SetUseRegEx()
        {
            scriptOnEventToolModel.UseRegEx = scriptOnEventToolView.UseRegexChecked;
        }
    }
}
