using DevExpress.ExpressApp;
using System;

namespace practica.Module.Controllers
{
    partial class ViewController1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }

        #endregion
    }
    public class RefreshAfterCommitController : ViewController1
    {
        bool needRefresh = false;
        public RefreshAfterCommitController()
        {
            TargetViewNesting = Nesting.Root;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.Committed += ObjectSpace_Committed;
            ObjectSpace.Committing += ObjectSpace_Committing;
            ObjectSpace.Reloaded += ObjectSpace_Reloaded;
        }
        protected override void OnDeactivated()
        {
            ObjectSpace.Committed -= ObjectSpace_Committed;
            ObjectSpace.Committing -= ObjectSpace_Committing;
            ObjectSpace.Reloaded -= ObjectSpace_Reloaded;
            base.OnDeactivated();
        }
        private void ObjectSpace_Reloaded(object sender, EventArgs e)
        {
            needRefresh = false;
        }
        private void ObjectSpace_Committing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var objectSpace = (IObjectSpace)sender;
            foreach (var obj in objectSpace.GetObjectsToSave(false))
            {
                if (objectSpace.IsNewObject(obj))
                {
                    needRefresh = true; break;
                }
            }
        }
        private void ObjectSpace_Committed(object sender, EventArgs e)
        {
            if (needRefresh)
            {
                ((IObjectSpace)sender).Refresh();
                needRefresh = false;
            }
        }
    }
}
