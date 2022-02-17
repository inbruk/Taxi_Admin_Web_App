using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

using Rapport.AuxiliaryTools.WUI;

namespace Rapport.Support.WUI.AuxiliaryWebUserControls
{
    [ParseChildren(true)]
    public partial class WindowLikeBorderPanel : System.Web.UI.UserControl
    {
        private ITemplate contents = null;

        [TemplateContainer(typeof(TemplateControl))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate Contents
        {
            get
            {
                return contents;
            }
            set
            {
                contents = value;
            }
        }

        public Int32 Width { set; get; }

        public Int32 Height { set; get; }

        public String Title { set; get; }

        public Boolean RefreshButtonEnabled { set; get; } = false;

        private Boolean _refreshCompleted = false;
        public void RefreshPanel()
        {
            if( RefreshButtonEnabled==true )
                divRefreshButton.Visible = true;
            else
                divRefreshButton.Visible = false;

            if (_refreshCompleted==false && contents != null)
            {
                TitleDiv.InnerText = Title;

                OuterDiv.Style["Width"] = Width.ToString() + "px";
                OuterDiv.Style["Height"] = Height.ToString() + "px";

                InnerTable.Style["Width"] = InnerDiv.Style["Width"] = (Width - 10).ToString() + "px";
                InnerTable.Style["Height"] = InnerDiv.Style["Height"] = (Height - 10).ToString() + "px";

                contents.InstantiateIn(pnlContent);
                _refreshCompleted = true;
            }
        }

        public Control getInternalControl(String ctrlName)
        {
            RefreshPanel();

            Control resCtrl = pnlContent.FindControl(ctrlName);
            return resCtrl;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        protected void ChangeEnableness(Boolean enableFlag)
        {
            List<Control> ctrls = this.GetAllSubControls().ToList();
            foreach(Control ctrl in ctrls)
            {
                RadTextBox radTextBox = ctrl as RadTextBox;
                if (radTextBox != null) radTextBox.Enabled = enableFlag;

                RadDropDownList radDropDownList = ctrl as RadDropDownList;
                if (radDropDownList != null) radDropDownList.Enabled = enableFlag;

                RadButton radButton = ctrl as RadButton;
                if (radButton != null) radButton.Enabled = enableFlag;

                RadNumericTextBox radNumericTextBox = ctrl as RadNumericTextBox;
                if (radNumericTextBox != null) radNumericTextBox.Enabled = enableFlag;
            }
        }

        protected Boolean _subControlsEnabled;
        public Boolean SubControlsEnabled
        {
            get
            {
                return _subControlsEnabled;
            }
            set
            {
                ChangeEnableness(value);
                _subControlsEnabled = value;
            }
        }
    }
}