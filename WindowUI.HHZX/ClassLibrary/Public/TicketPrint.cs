using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Text;


namespace WindowUI.HHZX.ClassLibrary.Public
{
    public class TicketPrint : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private Stream CreateStream(string name, string fileNameExtension,
          Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + DateTime.Now.Millisecond + "." + fileNameExtension,
              FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>EMF</OutputFormat>" +
            "  <PageWidth>48mm</PageWidth>" +
            "  <PageHeight>297mm</PageHeight>" +
            "  <MarginTop>0mm</MarginTop>" +
            "  <MarginLeft>0mm</MarginLeft>" +
            "  <MarginRight>0mm</MarginRight>" +
            "  <MarginBottom>0mm</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
              m_streams = new List<Stream>();
              try
              {
                  report.Render("Image", deviceInfo, CreateStream, out warnings);//一般情况这里会出错的  使用catch得到错误原因  一般都是简单错误
              }
              catch (Exception ex)
              {
                  Exception innerEx = ex.InnerException;//取内异常。因为内异常的信息才有用，才能排除问题。
                  while (innerEx != null)
                  {
                     //MessageBox.Show(innerEx.Message);
                     string errmessage = innerEx.Message;
                      innerEx = innerEx.InnerException;
                  }
              }
              foreach (Stream stream in m_streams)
              {
                  stream.Position = 0;
              }
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage =
              new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, 0, 0);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print(string printerName)
        {
            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            printDoc.OriginAtMargins = false;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".",
                  printerName);
                //Debug.WriteLine(msg);
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }
        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        /// <summary>
        /// 打印報表
        /// </summary>
        /// <param name="report"></param>
        /// <param name="printerName"></param>
        /// <returns></returns>
        public bool PrintTicket(LocalReport report, string printerName)
        {
            try
            {
                Export(report);
                m_currentPageIndex = 0;
                Print(printerName);

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
