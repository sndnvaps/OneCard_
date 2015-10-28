using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsUI.TQS.SystemForm
{
    public partial class MainPanel : UserControl
    {
        private int _QuitTime = 60;//退出時間
        private int _WaitTime = 0;//等待時間

        private Point _LastPoint;

        private List<ShowObj> _showList;

        private class ShowObj
        {
            public Panel ShowPanel;
            public BaseForm ShowForm;
            public string Name;
        }

        /// <summary>
        /// 是否啟用關閉計時
        /// </summary>
        public bool StopTimer
        {
            get
            {
                return this.tmrWait.Enabled;
            }
            set
            {
                this.tmrWait.Enabled = value;
            }
        }

        public MainPanel()
        {
            InitializeComponent();
            inti();
        }

        private void inti()
        {
            this.pnlMain.Controls.Clear();
            this.lblTitle.Text = "";
        }

        private void initTime()
        {
            //获取退出时间
            string time = System.Configuration.ConfigurationManager.AppSettings["WinForm_WaitTime"].ToString();
            if(!String.IsNullOrEmpty(time))
            {
                try
                {   
                    _QuitTime = Int32.Parse(time);
                }
                catch
                {
                    _QuitTime = 60;
                }
            }
        }

        /// <summary>
        /// 检查窗口是否已缓存
        /// </summary>
        /// <returns></returns>
        private bool CheckForm(string name)
        {
            if (_showList != null)
            {
                for (int index = 0; index < _showList.Count; index ++)
                {
                    if (_showList[index].Name == name)
                    {
                        return true;
                    }
                }
            }
            else
            {
                _showList = new List<ShowObj>();
            }

            return false;
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="name"></param>
        private void ShowForm(string name)
        {
            if (_showList != null)
            {
                for (int index = 0; index < _showList.Count; index++)
                {
                    if (_showList[index].Name == name)
                    {
                        _showList[index].ShowPanel.Visible = true;
                    }
                    else
                    {
                        _showList[index].ShowPanel.Visible = false;
                    }
                }
            }
        }

        public void Show(BaseForm showForm)
        {
            try
            {
                this.Visible = true;
                if (showForm != null)
                {
                    ShowObj sobj = new ShowObj();
                    sobj.ShowForm = showForm;
                    sobj.Name = showForm.Text; 

                    if(CheckForm(showForm.Text))
                    {
                        for (int index = 0; index < _showList.Count;index++ )
                        {
                            if (showForm.Text == _showList[index].Name)
                            {
                                sobj = _showList[index];
                            }
                        }
                    }
                    else//沒有缓存的Form，先缓存到List中
                    {
                        Panel pnl = new Panel();
                        pnl.Width = this.pnlMain.Width;
                        pnl.Height = this.pnlMain.Height;
                        //this.pnlMain.Controls.Clear();

                        foreach (Control ctl in showForm.Controls)
                        {
                            pnl.Controls.Add(ctl);

                            SetMouseEvent(ctl);
                        }

                        sobj.ShowPanel = pnl;

                        _showList.Add(sobj);
                        this.pnlMain.Controls.Add(sobj.ShowPanel);
                    }

                    this._WaitTime = 0;
                    this.tmrWait.Enabled = true;
                    this.lblTitle.Text = showForm.Text;

                    ShowForm(sobj.Name);
                    sobj.ShowForm.Show();
                }

                initTime();
            }
            catch
            {

            }
        }

        private void SetMouseEvent(Control ctl)
        {
            if(ctl.Controls != null)
            {
                for (int index = 0; index < ctl.Controls.Count;index++ )
                {
                    SetMouseEvent(ctl.Controls[index]);
                }
            }
            ctl.MouseMove += this.MainPanel_MouseMove;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_LastPoint == null)
            {
                _LastPoint = new Point(e.X, e.Y);
            }

            Point nowPoint = new Point(e.X, e.Y);
            //如果鼠标发生位移时，则证明正在进行操作
            if (nowPoint.X == _LastPoint.X && nowPoint.Y == _LastPoint.Y)
            {
                return;
            }
            else
            {
                _LastPoint = nowPoint;
                _WaitTime = 0;
            }
        }

        /// <summary>
        /// 關閉窗口
        /// </summary>
        private void ClosePanel()
        {
            if (GlobalVar.OpenFormList != null && GlobalVar.OpenFormList.Count > 0)
            {
                for (int index = 0; index < GlobalVar.OpenFormList.Count;index ++ )
                {
                    if (GlobalVar.OpenFormList[index] != null)
                    {
                        GlobalVar.OpenFormList[index].Close();
                    }
                }

                GlobalVar.OpenFormList.Clear();
            }

            //this.pnlMain.Controls.Clear();
            this.Visible = false;
            this._WaitTime = 0;
            this.tmrWait.Enabled = false;
            this.pnlQuit.Visible = false;
        }

        private void tmrWait_Tick(object sender, EventArgs e)
        {
            if (GlobalVar.AutoClose)
            {
                _WaitTime++;

                if (_WaitTime >= _QuitTime)
                {
                    ClosePanel();
                }
                else
                {
                    if ((_QuitTime - _WaitTime) < _QuitTime / 3)
                    {
                        this.pnlQuit.Visible = true;
                        this.lblQuitTime.Text = (_QuitTime - _WaitTime).ToString();
                    }
                    else
                    {
                        this.pnlQuit.Visible = false;
                    }
                }
            }
            else
            {
                _WaitTime = 0;
            }
            
        }
        
    }
}
