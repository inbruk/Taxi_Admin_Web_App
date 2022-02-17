using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rapport.AuxiliaryTools.WUI
{
    public static class WebControlExtentions
    {
        public static IEnumerable<Control> GetAllSubControls(this Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control descendant in GetAllSubControls(control))
                {
                    yield return descendant;
                }
            }
        }
    }
}