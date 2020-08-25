using Icarus.Components;
using Icarus.Logic.Game;
using Icarus.Logic.Game.Enums;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Icarus
{
    public partial class Main : Form
    {
        private readonly ProcessManager ProcessManager;
        private readonly CameraManager CameraManager;
        private readonly ProcessSource ProcessSource;

        public Main(ProcessManager processMgr, CameraManager cameraMgr)
        {
            InitializeComponent();

            ProcessManager = processMgr;
            CameraManager = cameraMgr;
            ProcessSource = new ProcessSource(lstProcs);

            CameraManager.CameraBound += CameraManager_CameraBound;
            CameraManager.CameraUnbound += CameraManager_CameraUnbound;
            CameraManager.FreeMoveStatusChanged += CameraManager_FreeMoveStatusChanged;
        }

        #region Main Form

        protected override CreateParams CreateParams => GetCreateParams();

        private void Main_Load(object sender, EventArgs e)
        {
            MinimumSize = MaximumSize = Size;
            SetFormState(false);
            lstRenderFlags.CameraManager = CameraManager;
            lstRenderFlags.Populate();

            tabContent.SelectedTab = tabProcs;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CameraManager.DisableFreeMove();
            CameraManager.ResetRenderFlags();
        }

        private void BtnTargetProc_Click(object sender, EventArgs e)
        {
            if (tabContent.SelectedTab == tabProcs)
                ProcessSource.Refresh();
            else
                tabContent.SelectedTab = tabProcs;
        }

        private void BtnToggleEnable_Click(object sender, EventArgs e)
        {
            CameraManager.ToggleFreeMove();
        }

        private void BtnResetFlags_Click(object sender, EventArgs e)
        {
            lstRenderFlags.SetDefaultFlags();
        }

        private void BtnPatchExe_Click(object sender, EventArgs e)
        {
            string message;

            if (ProcessManager.HasExited())
                message = "No active process selected.";
            else if (ProcessManager.PatchClient())
                message = "Patch successfully applied.\nA new executable is now located in the client directory.";
            else
                message = "Patch failed.\nEither the client executable is inaccessible or has already been patched.";

            MessageBox.Show(message, "Farclip Patch Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TabContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabContent.SelectedTab == tabProcs)
                ProcessSource.Refresh();
        }

        #endregion Main Form

        #region Main Tab

        private void TbSpeed_Scroll(object sender, EventArgs e)
        {
            CameraManager.MovementSpeed = tbSpeed.Value;
        }

        #endregion Main Tab

        #region Process Tab

        private void BtnRefreshProc_Click(object sender, EventArgs e)
        {
            ProcessSource.Refresh();
        }

        private void LstProcs_DoubleClick(object sender, EventArgs e)
        {
            if (lstProcs.SelectedItem is ProcessItem item)
            {
                try
                {
                    if (ProcessManager.Attach(Process.GetProcessById(item.ProcessID)))
                        tabContent.SelectedTab = tabMain;
                }
                catch (ArgumentException)
                {
                    ProcessSource.Refresh();
                }
            }
        }

        #endregion Process Tab

        #region Misc

        private CreateParams GetCreateParams()
        {
            var createParams = base.CreateParams;
            createParams.ExStyle |= 0x2000000; // WS_EX_COMPOSITED
            return createParams;
        }

        private void CameraManager_CameraBound(object sender, CameraStatus e)
        {
            string message = null;

            switch (e)
            {
                case CameraStatus.BuildNotFound:
                    message = $"Unimplemented client build ({ProcessManager.Build}) found.";
                    break;

                case CameraStatus.CameraNotFound:
                    message = "Unable to read the Camera object.\nPlease ensure you are in game.";
                    break;

                case CameraStatus.MemoryAccess:
                    message = $"Unable to access client memory.\nTry running {GetType().Namespace} as Administrator.";
                    break;

                case CameraStatus.PatternNotFound:
                    message = "Unable to find the Camera movement pattern.";
                    break;

                case CameraStatus.OK:
                    SetFormState(true);
                    return;
            }

            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CameraManager_CameraUnbound(object sender, EventArgs e)
        {
            SetFormState(false);
        }

        private void CameraManager_FreeMoveStatusChanged(object sender, bool e)
        {
            btnToggleEnable.Text = (e ? "Disable" : "Enable") + " Free Move";
        }

        private void SetFormState(bool enabled)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => SetFormState(enabled)));
                return;
            }

            tabMain.Enabled = enabled;
            btnToggleEnable.Enabled = enabled;
            btnToggleEnable.Text = (enabled ? "Disable" : "Enable") + " Free Move";
            btnResetFlags.Enabled = enabled;
            btnPatchExe.Enabled = enabled;
            lstRenderFlags.Enabled = enabled;
            lstRenderFlags.SetCurrentFlags();

            if (enabled)
                lblStatus.Text = $"Attached to PID {ProcessManager.Process.Id}";
            else
                lblStatus.Text = "No process attached";
        }

        #endregion Misc
    }
}