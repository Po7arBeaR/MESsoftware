using LogSerilog;
using MesInterface;
using MESsoftware1.micheckMarkAnddcPackForSfc;
using MESsoftware1.sfcBatchPack;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace MESsoftware1.MES
{

    public class MESCallCheckInterFace
    {
    //    static int lockedValue = 0;
        public ResponseResult CheckMarkAndDcPackForSfcCall(string barcode, MesRequestPara mesRequestPara)
        {
            //while (Interlocked.Exchange(ref lockedValue, 1) != 0)
            //{
            //    //此循环用于等待当前捕获current的线程执行结束
            //    Console.WriteLine("Locking");
            //    Thread.Sleep(TimeSpan.FromMilliseconds(50));
            //}
            ResponseResult responseResult = new ResponseResult();
            try
            {
                micheckMarkAnddcPackForSfc.MiCheckMarkAndDcPackForsfcServiceService serviceClient = new micheckMarkAnddcPackForSfc.MiCheckMarkAndDcPackForsfcServiceService();
                serviceClient.Url = mesRequestPara.Url;
                serviceClient.Timeout = mesRequestPara.TimeOut;
                serviceClient.Credentials = new NetworkCredential(mesRequestPara.UserName, mesRequestPara.Password);
                serviceClient.PreAuthenticate = true;
                CheckMarkAndDCForSfcRequest dataRequest = new CheckMarkAndDCForSfcRequest();
                dataRequest.site = mesRequestPara.RequestParameterList.Find(x => x.Key == "site")?.Value;
                dataRequest.operation = mesRequestPara.RequestParameterList.Find(x => x.Key == "operation")?.Value;
                dataRequest.resource = mesRequestPara.RequestParameterList.Find(x => x.Key == "resource")?.Value;
                dataRequest.sfc = barcode;
                miCheckMarkAndDCForSfc dataColletion = new miCheckMarkAndDCForSfc();
                dataColletion.CheckMarkAndDcForSfcRequest = dataRequest;
                responseResult.StartTime = DateTime.Now;
                miCheckMarkAndDCForSfcResponse checkresponse = serviceClient.miCheckMarkAndDCForSfc(dataColletion);
                responseResult.Sfc = checkresponse.@return.sfc;
                responseResult.lableRemarks = checkresponse.@return.labelRemarks;
                responseResult.GroupCode = checkresponse.@return.groupCode;
                responseResult.GropBasis = checkresponse.@return.groupBasis;
                responseResult.Code = checkresponse.@return.code;
                responseResult.Message = checkresponse.@return.message;
                if(responseResult.GropBasis == mesRequestPara.RequestParameterList.Find(x => x.Key == "Mark1CheckCode")?.Value)
                {
                    responseResult.JgeMarkBrach = 1;
                }
                else if(responseResult.GropBasis == mesRequestPara.RequestParameterList.Find(x => x.Key == "Mark2CheckCode")?.Value)
                {
                    responseResult.JgeMarkBrach = 2;
                }
                else
                {
                    responseResult.JgeMarkBrach = 3;

                }
                responseResult.EndTime = DateTime.Now;

            }
            catch (Exception ex)
            {
                LogSerilog.SerilogHelper.MESErrorAsync(ex, $"【电芯分流接口】调用接口失败{ex.Message}", MESInterfaceType.Check);
                if (ex.Message== "操作超时"&& mesRequestPara.TimeOutReConnectTime<=0)
                {

                    mesRequestPara.TimeOutReConnectTime--;
                    LogSerilog.SerilogHelper.MESErrorAsync(ex,  $"【电芯分流接口】操作超时 {mesRequestPara.ReConnectWaitTime}ms后重新调用接口.重连次数{mesRequestPara.TimeOutReConnectTime}", MESInterfaceType.Check);
                    Thread.Sleep(mesRequestPara.ReConnectWaitTime);
                    responseResult = CheckMarkAndDcPackForSfcCall(barcode, mesRequestPara);
                }
                else
                {
                    responseResult.Code = -1;
                    responseResult.Message = string.Format("【电芯分流接口】接口调用失败,模组条码：【{0}】.原因：{1}", barcode, ex.Message);
                    responseResult.EndTime = DateTime.Now;
                    responseResult.GropBasis = "Error";
                    responseResult.GroupCode = "Error";
                    responseResult.lableRemarks = "Error";
                    responseResult.Sfc = "Error";
                    responseResult.JgeMarkBrach = -1;
                }
            
            }
            //Interlocked.Exchange(ref lockedValue, 0);
            return responseResult;
        }


      
    }
    public class MESCallBatchInterface
    {
       
      //  static int lockedValue = 0;
        public ResponseResult SfcBatchPackCall(List<requestSfcDetail> sfclist ,string packGroup  , MesRequestPara mesRequestPara)
        {
           
            //while (Interlocked.Exchange(ref lockedValue, 1) != 0)
            //{
            //    //此循环用于等待当前捕获current的线程执行结束
            //    Thread.Sleep(TimeSpan.FromMilliseconds(50));
            //}
            ResponseResult responseResult = new ResponseResult();
            try
            {
                sfcBatchPack.MiAddCheckMarkAndPackForsfcBatchServiceService serviceClient=new MiAddCheckMarkAndPackForsfcBatchServiceService();
                serviceClient.Url = mesRequestPara.Url;
                serviceClient.Timeout = mesRequestPara.TimeOut;
                serviceClient.Credentials = new NetworkCredential(mesRequestPara.UserName, mesRequestPara.Password);
                serviceClient.PreAuthenticate = true;
                sfcBatchPack.miAddCheckMarkAndPackForsfcRequest datarequest = new sfcBatchPack.miAddCheckMarkAndPackForsfcRequest();
                datarequest.sfcList= sfclist.ToArray();
                datarequest.site = mesRequestPara.RequestParameterList.Find(x => x.Key == "site")?.Value;
                datarequest.resource = mesRequestPara.RequestParameterList.Find(x => x.Key == "resource")?.Value;
                datarequest.activity = mesRequestPara.RequestParameterList.Find(x => x.Key == "activity")?.Value;
                datarequest.operation = mesRequestPara.RequestParameterList.Find(x => x.Key == "operation")?.Value;
                datarequest.checkMarking = ((mesRequestPara.RequestParameterList.Find(x => x.Key == "checkMarking")?.Value) == "true") ? true : false;
                datarequest.container = mesRequestPara.RequestParameterList.Find(x => x.Key == "container")?.Value;
                datarequest.containerNumber = mesRequestPara.RequestParameterList.Find(x => x.Key == "containerNumber")?.Value;
                datarequest.closeContainer = int .Parse(sfclist[sfclist.Count-1].sequence)>=int .Parse( mesRequestPara.RequestParameterList.Find(x=>x.Key=="capacity")?.Value);
                datarequest.packGroup = packGroup;
                sfcBatchPack.miAddCheckMarkAndPackForsfcBatch datacollection = new miAddCheckMarkAndPackForsfcBatch();
                datacollection.MiAddCheckMarkAndPackForsfcRequest=datarequest;
                responseResult.StartTime = DateTime.Now;
                sfcBatchPack.miAddCheckMarkAndPackForsfcBatchResponse response= serviceClient.miAddCheckMarkAndPackForsfcBatch(datacollection);
                responseResult.EndTime = DateTime.Now;
                responseResult.Code= response.@return.code;
                responseResult.Message= response.@return.message;
                responseResult.RetSfcList = response.@return.sfcList.ToList();
               
            }
            catch (Exception ex)
            {
               LogSerilog.SerilogHelper.MESErrorAsync(ex, $"【电芯批量打包】调用接口失败[{ex.Message}]", MESInterfaceType.Batch);
                if (ex.Message == "操作超时"&& mesRequestPara.TimeOutReConnectTime<=0)
                {
                    mesRequestPara.TimeOutReConnectTime--;
                    LogSerilog.SerilogHelper.MESErrorAsync(ex, $"【电芯批量打包】:{ex.Message} .[{mesRequestPara.ReConnectWaitTime}]ms后重新调用接口,重连次数:{mesRequestPara.TimeOutReConnectTime}", MESInterfaceType.Batch);
                    Thread.Sleep(mesRequestPara.ReConnectWaitTime);
                    responseResult= SfcBatchPackCall(sfclist, packGroup,mesRequestPara);
                }
                else
                {
                    string str = "";
                    foreach (var item in sfclist)
                    {
                        str +='['+ item.sfc + "]";
                    }
                    responseResult.Code = -1;
                    responseResult.Message = string.Format("【电芯批量打包】接口调用失败,模组条码：{0},原因：{1}", str, ex.Message);
                    responseResult.EndTime = DateTime.Now;
                   
                }
             
                //string.Format("【刻码_电芯校验】调用MES接口失败，出现异常。模组条码：【{0}】，电芯条码集合:【{1}】,原因：{2}", moduleBarcode, string.Join(",", cellBarcodes), ex.Message);
            }
         //   Interlocked.Exchange(ref lockedValue, 0);
            return responseResult;
        }
    }
}