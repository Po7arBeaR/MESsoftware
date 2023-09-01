using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K4os.Compression.LZ4.Streams.Abstractions;
using Org.BouncyCastle.Utilities;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using SqlSugar;
using Sunny.UI;
using static NPOI.HSSF.Util.HSSFColor;




namespace LogSerilog
{
  public  enum MESInterfaceType
    {
        Check,
        Batch
    }

    public static class SerilogHelper
    {
        public static Serilog.ILogger _SystemLogger;
        public static Serilog.ILogger CheckNDcPackLog;
        public static Serilog.ILogger AddCheckNBatchLog;
        public static RichTextBox RuntimeTextBox;
        public static RichTextBox MESLogTextBox;
        delegate void txbLogPrintDelegate(string str);
        delegate void txbLogScrollelegate();
        delegate string txbLogTextLength();
        public static void Configure( string BatchLogPath,string BranchLogPath)
        {
            string branchPath = "";
            string BatchPath = "";
            if(string.IsNullOrEmpty(BatchLogPath) || string.IsNullOrEmpty(BranchLogPath))
            {
                branchPath= @"D:\";
                BatchPath = @"D:\";
            }
            else
            {
                BatchPath= BatchLogPath;
                branchPath = BranchLogPath;
            }
         //   var csvFormatter = new CsvFormatter(renderMessage: true);
            _SystemLogger = new LoggerConfiguration()
      .WriteTo.File( "logs\\log-.txt", rollingInterval: RollingInterval.Day)
      .CreateLogger();

            CheckNDcPackLog = new LoggerConfiguration()
      .WriteTo.File(branchPath + "meslog\\打包分组-MiCheckMarkAndDcPackForsfc\\.csv", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff zzz},[{Level:u3}],{Message:utf-8}{NewLine}{Exception}",encoding: new System.Text.UTF8Encoding(true))
      .CreateLogger();
            AddCheckNBatchLog= new LoggerConfiguration()
      .WriteTo.File(BatchPath + "meslog\\自动打包-MiAddCheckMarkAndPackForSfcBatch\\.csv", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff zzz},[{Level:u3}],{Message:utf-8}{NewLine}{Exception}", encoding: new System.Text.UTF8Encoding(true))
      .CreateLogger();
        }
        public static void ConnectTextBox(ref RichTextBox richTextBox1, ref RichTextBox richTextBox2)
        {
            RuntimeTextBox=new RichTextBox();
            MESLogTextBox=new RichTextBox();
            RuntimeTextBox =  richTextBox1;
            MESLogTextBox =  richTextBox2;
        }
        public static async Task RuntimeInformationAsync(string message)
        {
            await RuntimeLogAsync(message, Serilog.Events.LogEventLevel.Information);
        }

        public static async Task RuntimeDebugAsync(string message)
        {
            await RuntimeLogAsync(message, Serilog.Events.LogEventLevel.Debug);
        }

        public static async Task RuntimeErrorAsync(Exception ex, string message)
        {
            await RunTimeErrorLogAsybc(message, Serilog.Events.LogEventLevel.Error, ex);
        }
        private static async Task RuntimeLogAsync(string message, Serilog.Events.LogEventLevel level, Exception ex = null)
        {
            _SystemLogger.Write(level, ex, message);

            await Task.Run(() =>
            {
                RuntimeTextBox.BeginInvoke(new Action(() => { RuntimeTextBox.SelectionColor = Color.Black; }));
                RuntimeTextBox.Invoke((txbLogPrintDelegate)RuntimeTextBox.AppendText, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}:{message} \r\n");
                //      InteractTextBox.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}->{message}\n");
                RuntimeTextBox.Invoke((txbLogScrollelegate)RuntimeTextBox.ScrollToCaret);
            });
        }
        private static async Task RunTimeErrorLogAsybc(string message, Serilog.Events.LogEventLevel level, Exception ex)
        {
            _SystemLogger.Write(level, ex, message);
            await Task.Run(() =>
            {
                RuntimeTextBox.BeginInvoke(new Action(() => { RuntimeTextBox.SelectionColor = Color.Red; }));
                if (ex!=null)
                {
                    RuntimeTextBox.Invoke((txbLogPrintDelegate)RuntimeTextBox.AppendText, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}:{message}[ex:]{ex.Message}\r\n");
                }
                else
                {
                    RuntimeTextBox.Invoke((txbLogPrintDelegate)RuntimeTextBox.AppendText, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}:{message} \r\n");
                }
                //      InteractTextBox.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}->{message}\n");
                RuntimeTextBox.Invoke((txbLogScrollelegate)RuntimeTextBox.ScrollToCaret);
            }
            );
        }
        public static async Task MESInformationAsync(string message, MESInterfaceType type)
        {
            await MESLogAsync(message, Serilog.Events.LogEventLevel.Information, type);
        }

        public static async Task MESDebugAsync(string message, MESInterfaceType type)
        {
            await MESLogAsync(message, Serilog.Events.LogEventLevel.Debug,type);
        }

        public static async Task MESErrorAsync(Exception ex, string message, MESInterfaceType type)
        {
            await MESErrorLogAsync(message, Serilog.Events.LogEventLevel.Error, ex,  type);
        }
      
        private static async Task MESLogAsync(string message, Serilog.Events.LogEventLevel level, MESInterfaceType type)
        {
            try
            {
                if (type == MESInterfaceType.Check)
                {
                    CheckNDcPackLog.Write(level, message);
                }
                if (type == MESInterfaceType.Batch)
                {
                    AddCheckNBatchLog.Write(level, message);
                }

                await Task.Run(() =>
                {
                    MESLogTextBox.BeginInvoke(new Action(() => { MESLogTextBox.SelectionColor = Color.Black; }));
                    MESLogTextBox.Invoke((txbLogPrintDelegate)MESLogTextBox.AppendText, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}->{message}\r\n");
                    //      InteractTextBox.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}->{message}\n");
                    MESLogTextBox.Invoke((txbLogScrollelegate)MESLogTextBox.ScrollToCaret);
                });
            }
            catch (Exception)
            {

                throw;
            }
        
        }
        private static async Task MESErrorLogAsync(string message, Serilog.Events.LogEventLevel level, Exception ex,MESInterfaceType type )
        {
            try
            {
                if (type == MESInterfaceType.Check)
                {
                   
                  
                    CheckNDcPackLog.Write(level,  message);
                }
                if (type == MESInterfaceType.Batch)
                {
                    AddCheckNBatchLog.Write(level,  message);
                }

                await Task.Run(() =>
                {
                    MESLogTextBox.BeginInvoke(new Action(() => { MESLogTextBox.SelectionColor = Color.Red; }));
                    if (ex != null)
                    {
                        MESLogTextBox.Invoke((txbLogPrintDelegate)MESLogTextBox.AppendText, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}:{message}【信息:{ex.Message}】\r\n");
                    }
                    else
                    {
                        MESLogTextBox.Invoke((txbLogPrintDelegate)MESLogTextBox.AppendText, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}:{message}\r\n ");
                    }
                  //  MESLogTextBox.Invoke((txbLogPrintDelegate)MESLogTextBox.AppendText, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}->[ex:]{ex.Message}");
                    //      InteractTextBox.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}->{message}\n");
                    MESLogTextBox.Invoke((txbLogScrollelegate)MESLogTextBox.ScrollToCaret);
                });
            }
            catch (Exception)
            {

                throw;
            }
          
        }

    }

}
