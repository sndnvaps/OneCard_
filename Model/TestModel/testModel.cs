using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TestModel
{
    public class testModel : Model.IModel.IModelObject
    {
        public testModel()
        {
            this.iID = 0;

            this.cTxt1 = string.Empty;

            this.cTxt2 = string.Empty;

            this.cTxt3 = string.Empty;

            this.cTxt4 = string.Empty;

            this.cTxt5 = string.Empty;

            this.iNum1 = 0;

            this.iNum2 = 0;

            this.iNum3 = 0;

            this.iNum4 = 0;

            this.iNum5 = 0;

            this.RecordID = 0;
        }

        public int iID { get; set; }

        public string cTxt1 { get; set; }

        public string cTxt2 { get; set; }

        public string cTxt3 { get; set; }

        public string cTxt4 { get; set; }

        public string cTxt5 { get; set; }

        public int iNum1 { get; set; }

        public int iNum2 { get; set; }

        public int iNum3 { get; set; }

        public int iNum4 { get; set; }

        public int iNum5 { get; set; }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
