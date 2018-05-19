using System.Web.UI;
using DevExpress.ExpressApp;

namespace WinWebSolution.Module.Web {
    public class WebShowCustomFormWindowController : ShowCustomFormWindowController {
        string customFormPath = "CustomUserControls/WebCustomForm.aspx";
        protected override void ShowCustomNonModalForm() {
            Page page = (Page)Frame.Template;

            string script = @"<script>
                                var openedWindow = window.open(""" + customFormPath + @""",""test"", ""toolbar=no,menubar=no,width=600,height=600,resizable=no, center=yes"");
                            </script>";
            page.ClientScript.RegisterStartupScript(GetType(), "clientScriptForNonModalWindow", script);
        }
        protected override void ShowCustomModalForm() {
            Page page = (Page)Frame.Template;

            string script = @"<script>
                                window.showModalDialog(""" + customFormPath + @""",""#1"",""dialogHeight: 600px; dialogWidth: 600px;dialogTop: 190px;  dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;"");
                            </script>";
            page.ClientScript.RegisterStartupScript(GetType(), "clientScriptForModalWindow", script);
        }
    }
}