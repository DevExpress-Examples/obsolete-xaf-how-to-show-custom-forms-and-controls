using System;
using WinCustomUserControlLibrary;

namespace WinWebSolution.Module.Win {
    public class WinShowCustomFormWindowController : ShowCustomFormWindowController {
        protected override void ShowCustomNonModalForm() {
            WinCustomForm form = new WinCustomForm();
            form.Text = GetWindowCaption();
            form.Show();
        }
        protected override void ShowCustomModalForm() {
            using (WinCustomForm form = new WinCustomForm()) {
                form.Text = GetWindowCaption();
                form.ShowDialog();
            }
        }
    }
}
