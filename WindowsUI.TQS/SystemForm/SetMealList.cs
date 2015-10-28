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
    public partial class SetMealList : UserControl
    {
        private SetMealInfo _mealInfo;

        public SetMealList(SetMealInfo mealInfo)
        {
            _mealInfo = mealInfo;

            InitializeComponent();
            inti();
        }

        public void inti()
        {
            if (_mealInfo != null)
            {
                this.lblDate.Text = _mealInfo.times.ToString("yyyy/MM/dd");
                this.lblWeek.Text = GetWeeks(_mealInfo.times);
                SetMealStarus(this.lblBreakfast, _mealInfo.Breakfast);
                SetMealStarus(this.lblLunch, _mealInfo.Lunch);
                SetMealStarus(this.lblDinner, _mealInfo.Dinner);

                if (DateTime.Parse(_mealInfo.times.ToString("yyyy/MM/dd")) == DateTime.Parse(System.DateTime.Now.ToString("yyyy/MM/dd")))
                {
                    this.BackColor = System.Drawing.Color.FromArgb(157, 215, 249);
                }
            }
            else
            {
                this.BackColor = Color.Gray;
            }
        }

        private String GetWeeks(DateTime dtime)
        {
            string week = "";

            string dt = dtime.DayOfWeek.ToString().ToLower();
            switch (dt)
            {
                case "monday":
                    week = "星期一";
                    break;
                case "tuesday":
                    week = "星期二";
                    break;
                case "wednesday":
                    week = "星期三";
                    break;
                case "thursday":
                    week = "星期四";
                    break;
                case "friday":
                    week = "星期五";
                    break;
                case "saturday":
                    week = "星期六";

                    //this.BackColor = Color.LightGray;
                    this.lblDate.ForeColor = Color.OrangeRed;
                    this.lblWeek.ForeColor = Color.OrangeRed;

                    break;
                case "sunday":
                    week = "星期日";

                    //this.BackColor = Color.LightGray;
                    this.lblDate.ForeColor = Color.OrangeRed;
                    this.lblWeek.ForeColor = Color.OrangeRed;

                    break;
            }

            return week;
        }

        private void SetMealStarus(Label tagLbl,bool? status)
        {
            if (status != null)
            {
                if ((bool)status)
                {
                    tagLbl.ForeColor = Color.Blue;
                    tagLbl.Text = "开餐";
                }
                else
                {
                    tagLbl.ForeColor = Color.Red;
                    tagLbl.Text = "停餐";
                }
            }
            else
            {
                tagLbl.ForeColor = Color.Gray;
                tagLbl.Text = "--";

            }
        }
    }
}
