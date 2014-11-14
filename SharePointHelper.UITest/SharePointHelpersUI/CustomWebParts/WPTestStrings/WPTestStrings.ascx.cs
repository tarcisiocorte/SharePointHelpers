using SharePointHelpers.Utils.String;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace SharePointHelpersUI.CustomWebParts.WPTestStrings
{
    [ToolboxItemAttribute(false)]
    public partial class WPTestStrings : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public WPTestStrings()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (StringHelpers.StringIsNullOrEmpty(this.txt1.Text) == string.Empty)
                this.txt2.Text = "O TextBox anterior esta vazio";
            else
                this.txt2.Text = this.txt1.Text;
        }
    }
}
