using HansPlcAPI;
using MESsoftware1.SQL;
using NPOI.HPSF;
using Org.BouncyCastle.Cms;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPLC
{
    public class PlcOperator
    {
        /// <summary>
        /// 读取西门子S7对象的类
        /// </summary>
        public static Plc_ModbusTcp m_PlcTcp = null;

        /// <summary>
        /// PLC连接状态，为false时为未连接，为true是代表连接西门子PLC并握手成功
        /// </summary>
        public static bool PlcConnectStatus
        {
            get
            {
                return m_PlcTcp != null && m_PlcTcp.m_plcReady;
            }
        }

        /// <summary>
        /// 连接西门子PLC，只读取 反馈信号
        /// 因蔚来Busbar的Redis数据项很多【约15000】，Redis刷新周期比较慢，导致不能实时读取PLC的反馈信号数据
        /// </summary>
        /// <param name="siemensIP"></param>
        /// <returns></returns>
        public static bool ConnectSiemensPlc(string siemensIP, int port = 102, string localIp = "127.0.0.1")
        {
            m_PlcTcp = new SiemensS7_TcpIp(siemensIP, port, localIp, SiemensPLCS.S1500);
            /*
             * IniPlcCon()方法本质是依次执行三个函数
             * ClosePLC();
             * ConnectPLC();
             * HandShakeWithPlc();
            */
            bool result = m_PlcTcp.IniPlcCon();
            m_PlcTcp.SetRcvDataSleepTime(20);//设置时间
            //m_PlcTcp.m_isConnectSucess
            return result;
        }

        /// <summary>
        /// 停止与PLC通讯
        /// </summary>
        public static void StopPlcCon()
        {
            m_PlcTcp?.ClosePLC();
        }

        #region DB块读取
        /// <summary>
        /// 单个bool读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">地址</param>
        /// <param name="_boolValue">返回值</param>
        /// <returns></returns>      
        public static bool DB_ReadBool(short _dbNum, int _addr, ref bool _boolValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadBool(_dbNum, _addr, ref _boolValue);
        }
        /// <summary>
        /// 多个bool一起读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">地址</param>
        /// <param name="_boolArr_Value">返回值</param>
        /// <returns></returns>
        public static bool DB_ReadBool_S(short _dbNum, int _addr, ref bool[] _boolArr_Value)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadBool_S(_dbNum, _addr, ref _boolArr_Value);
        }

        /// <summary>
        /// 单个Real读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">地址</param>
        /// <param name="_floatValue">返回值</param>
        /// <returns></returns>
        public static bool DB_ReadReal(short _dbNum, int _addr, ref float _floatValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadReal(_dbNum, _addr, ref _floatValue);
        }
        /// <summary>
        /// 单个Word读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">地址</param>
        /// <param name="_shortValue">返回值</param>
        /// <returns></returns>
        public static bool DB_ReadWordOrInt(short _dbNum, int _addr, ref short _shortValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadWordOrInt(_dbNum, _addr, ref _shortValue);
        }

        /// <summary>
        /// 单个byte读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">地址</param>
        /// <param name="_ByteValue">返回值</param>
        /// <returns></returns>
        public static bool DB_ReadByte(short _dbNum, int _addr, ref byte _ByteValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadByte(_dbNum, _addr, ref _ByteValue);
        }
        /// <summary>
        /// 多个Byte读取--最多200
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">db块地址</param>
        /// <param name="_ByteValue"></param>
        /// <returns></returns>
        public static bool DB_ReadByte_S(short _dbNum, int _addr, ref byte[] _ByteValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadByte_S(_dbNum, _addr, ref _ByteValue);
        }

        /// <summary>
        /// 多个Byte读取--最多200
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">db块地址</param>
        /// <param name="_ByteValue"></param>
        /// <returns></returns>
        public static bool DB_ReadByte_Any(short _dbNum, int _addr, ref byte[] _ByteValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadByte_Any(_dbNum, _addr, ref _ByteValue);
        }
        /// <summary>
        /// 多个Real读取--最多50
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">db块地址</param>
        /// <param name="_floatValue"></param>
        /// <returns></returns>
        public static bool DB_ReadReal_S(short _dbNum, int _addr, ref float[] _floatValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadReal_S(_dbNum, _addr, ref _floatValue);
        }
        /// <summary>
        /// 单个DWord或DINT读取
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_intValue"></param>
        /// <returns></returns>
        public static bool DB_ReadDWordOrDInt(short _dbNum, int _addr, ref int _intValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadDWordOrDInt(_dbNum, _addr, ref _intValue);
        }
        /// <summary>
        /// 多个Word读取---最多100个
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">db块地址</param>
        /// <param name="_shortValue"></param>
        /// <returns></returns>
        public static bool DB_ReadWordOrInt_S(short _dbNum, int _addr, ref short[] _shortValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadWordOrInt_S(_dbNum, _addr, ref _shortValue);
        }
        /// <summary>
        /// 单个LReal读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">db块地址</param>
        /// <param name="_doubleValue"></param>
        /// <returns></returns>
        public static bool DB_Read_LReal(short _dbNum, int _addr, ref double _doubleValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_Read_LReal(_dbNum, _addr, ref _doubleValue);
        }
        /// <summary>
        /// 多个LReal读取--最多25个
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_doubleValue"></param>
        /// <returns></returns>
        public static bool DB_Read_LReal_S(short _dbNum, int _addr, ref double[] _doubleValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_Read_LReal_S(_dbNum, _addr, ref _doubleValue);
        }
        /// <summary>
        /// 多个DINT 读取--最多50个
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_intValue"></param>
        /// <returns></returns>
        public static bool DB_ReadDWordOrDInt_S(short _dbNum, int _addr, ref int[] _intValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadDWordOrDInt_S(_dbNum, _addr, ref _intValue);
        }
        /// <summary>
        /// 单个字符串 读取--最大长度100
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_strLength"></param>
        /// <param name="_strValue"></param>
        /// <returns></returns>
        public static bool DB_ReadString(short _dbNum, int _addr, ushort _strLength, ref string _strValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_ReadString(_dbNum, _addr, _strLength, ref _strValue);
        }

        #endregion

        #region DB块写入
        /// <summary>
        /// 单个字符串写入---最多写200个
        /// </summary>
        /// <param name="_dbNum">db号</param>
        /// <param name="_addr">db地址</param>
        /// <param name="_strValue">字符串</param>
        /// <returns></returns>
        public static bool DB_WriteString(short _dbNum, int _addr, string _strValue)
        {
            if (_strValue.Length > 200)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteString(_dbNum, _addr, _strValue);
        }
        /// <summary>
        /// 单个Dword或者DINT写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_intValue"></param>
        /// <returns></returns>
        public static bool DB_WriteDWordOrDInt(short _dbNum, int _addr, int _intValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteDWordOrDInt(_dbNum, _addr, _intValue);
        }
        public static bool DB_WriteDWord(short _dbNum, int _addr, uint _intValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteDWord(_dbNum, _addr, _intValue);
        }

        public static bool DB_WriteWord(short _dbNum, int _addr, ushort _shortValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteWord(_dbNum, _addr, _shortValue);
        }
        /// <summary>
        /// 单个word或者Int写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_shortValue"></param>
        /// <returns></returns>
        public static bool DB_WriteWordOrInt(short _dbNum, int _addr, short _shortValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteWordOrInt(_dbNum, _addr, _shortValue);
        }

        /// <summary>
        /// 单个Byte或者Int写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_ByteValue"></param>
        /// <returns></returns>
        public static bool DB_WriteByte(short _dbNum, int _addr, byte _ByteValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteByte(_dbNum, _addr, _ByteValue);
        }
        /// <summary>
        /// 单个Real写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_floatValue"></param>
        /// <returns></returns>
        public static bool DB_WriteReal(short _dbNum, int _addr, float _floatValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteReal(_dbNum, _addr, _floatValue);
        }

        /// <summary>
        /// 多个Real写入，这里按照最多100个连续REAL进行处理。
        /// 测试单次最大113个REAL连续，114个REAL的时候会操作地址失败,对应字节数452
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static bool DB_WriteReal_S(short _dbNum, int _addr, float[] _val)
        {
            if (_addr > 65535 || _addr < 0 || _val.Length > 100)
            {
                //测试单次最大113个，114的时候会操作地址失败   对应字节数452和456
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteReal_S(_dbNum, _addr, _val);
        }

        /// <summary>
        /// 多个DInt写入，这里按照最多100个连续DINT进行处理
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static bool DB_WriteDInt_S(short _dbNum, int _addr, int[] _val)
        {
            if (_addr > 65535 || _addr < 0 || _val.Length > 100)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteDInt_S(_dbNum, _addr, _val);
        }
        /// <summary>
        /// 多个Int16写入，这里按照最多200个连续INT进行处理
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static bool DB_WriteInt_S(short _dbNum, int _addr, short[] _val)
        {
            if (_addr > 65535 || _addr < 0 || _val.Length > 200)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteInt_S(_dbNum, _addr, _val);
        }
        /// <summary>
        /// 多个String写入，总的字节数不超过400.按50一个，最多只有8个
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static bool DB_WriteString_S(short _dbNum, int _addr, string[] _val)
        {
            //总的字节数不超过400.按50一个，最多只有8个
            if (_addr > 65535 || _addr < 0 || _val.Length > 8)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteString_S(_dbNum, _addr, _val);
        }
        /// <summary>
        /// 多个BYTE写入，最多400个字节
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static bool DB_WriteByte_S(short _dbNum, int _addr, byte[] _val)
        {
            if (_addr > 65535 || _addr < 0 || _val.Length > 400)
            {
                //测试单次最大113个，114的时候会操作地址失败   对应字节数452和456
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteByte_S(_dbNum, _addr, _val);
        }
        /// <summary>
        /// 单个LReal写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_floatValue"></param>
        /// <returns></returns>
        public static bool DB_Write_LReal(short _dbNum, int _addr, double _floatValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_Write_LReal(_dbNum, _addr, _floatValue);
        }

        /// <summary>
        /// 单个bool写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_boolValue"></param>
        /// <returns></returns>
        public static bool DB_WriteBool(short _dbNum, int _addr, bool _boolValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.DB_WriteBool(_dbNum, _addr, _boolValue);
        }
        #endregion

        #region M区读写
        /// <summary>
        /// 读单个word
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_retWord"></param>
        /// <param name="_retDouble"></param>
        /// <param name="_retFloat"></param>
        /// <returns></returns>
        public static bool M_ReadWord(int _addr, ref int _shortValue)
        {
            int[] _word = new int[1];
            _word[0] = _shortValue;
            bool rtn = M_ReadWord(_addr, ref _word);
            _shortValue = _word[0];
            return rtn;
        }
        /// <summary>
        /// 读多个BYTE地址,最多200
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_retWord"></param>
        /// <param name="_retDouble"></param>
        /// <param name="_retFloat"></param>
        /// <returns></returns>
        public static bool M_ReadByte(int _addr, ref byte[] _byte)
        {
            if (_addr > 65535 || _addr < 0 || _byte.Length > 200)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_ReadByte(_addr, ref _byte);
        }

        /// <summary>
        /// 读取任意多个字节，如果超过400个，就自动连续读
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_ByteValue"></param>
        /// <returns></returns>
        public static bool M_ReadByte_Any(int _addr, ref byte[] _ByteValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_ReadByte_Any(_addr, ref _ByteValue);
        }
        /// <summary>
        /// 西门子写Byte
        /// </summary>
        /// <param name="startAddr"></param>
        /// <param name="charArray">char数组，必须是偶数</param>
        /// <returns></returns>
        public static bool M_WriteByte(int startAddr, char[] charArray)
        {
            if (charArray.Length % 2 != 0)
            {
                throw new Exception("只允许长度设为偶数");
            }
            if (startAddr < 0 || startAddr > 65535)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteByte(startAddr, charArray);
        }
        /// <summary>
        /// 读多个WORD地址,最多100个字【也就是最多200个字节】
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_retWord"></param>
        /// <param name="_retDouble"></param>
        /// <param name="_retFloat"></param>
        /// <returns></returns>
        public static bool M_ReadWord(int _addr, ref int[] _word)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_ReadWord(_addr, ref _word);
        }

        /// <summary>
        /// 读多个DInt，最多50个
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_retWord"></param>
        /// <param name="_retDouble"></param>
        /// <param name="_retFloat"></param>
        /// <returns></returns>
        public static bool M_ReadDIntOrDWord(int _addr, ref int[] _dInt)
        {
            if (_addr > 65535 || _addr < 0 || _dInt.Length > 50)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_ReadDIntOrDWord(_addr, ref _dInt);
        }

        /// <summary>
        /// 写M取地址
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static bool M_WriteWord(int _addr, int _val)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteWord(_addr, _val);
        }

        /// <summary>
        /// 单个dword或者dInt写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_shortValue"></param>
        /// <returns></returns>
        public static bool M_WriteDIntOrDWord(int _addr, int _val)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteDIntOrDWord(_addr, _val);
        }
        public static bool M_WriteDWord(int _addr, uint _val)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteDWord(_addr, _val);
        }
        /// <summary>
        /// 单个word或者Int写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_shortValue"></param>
        /// <returns></returns>
        public static bool M_WriteWordOrInt(int _addr, short _shortValue)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteWordOrInt(_addr, _shortValue);
        }
        /// <summary>
        /// 单个Real写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_floatValue"></param>
        /// <returns></returns>
        public static bool M_WriteReal(int _addr, float _floatValue)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteReal(_addr, _floatValue);
        }
        /// <summary>
        /// 单个LReal写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_floatValue"></param>
        /// <returns></returns>
        public static bool M_Write_LReal(int _addr, double _doubleValue)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_Write_LReal(_addr, _doubleValue);
        }

        /// <summary>
        /// 单个Real读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">地址</param>
        /// <param name="_floatValue">返回值</param>
        /// <returns></returns>
        public static bool M_ReadReal(int _addr, ref float _floatValue)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_ReadReal(_addr, ref _floatValue);
        }
        /// <summary>
        /// 单个LReal读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">db块地址</param>
        /// <param name="_doubleValue"></param>
        /// <returns></returns>
        public static bool M_Read_LReal(int _addr, ref double _doubleValue)
        {
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_Read_LReal(_addr, ref _doubleValue);
        }
        /// <summary>
        /// 单个bool读取
        /// </summary>
        /// <param name="_dbNum">db块号</param>
        /// <param name="_addr">地址</param>
        /// <param name="_boolValue">返回值</param>
        /// <returns></returns>      
        public static bool M_ReadBool(int _addr, ref bool _boolValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_ReadBool(_addr, ref _boolValue);
        }
        /// <summary>
        /// 单个bool写入
        /// </summary>
        /// <param name="_dbNum"></param>
        /// <param name="_addr"></param>
        /// <param name="_boolValue"></param>
        /// <returns></returns>
        public static bool M_WriteBool(int _addr, bool _boolValue)
        {
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteBool(_addr, _boolValue);
        }

        /// <summary>
        /// 单个字符串写入---最多写200个
        /// </summary>
        /// <param name="_dbNum">db号</param>
        /// <param name="_addr">db地址</param>
        /// <param name="_strValue">字符串</param>
        /// <returns></returns>
        public static bool M_WriteString(int _addr, string _strValue)
        {
            if (_strValue.Length > 200)
            {
                return false;
            }
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteString(_addr, _strValue);
        }

        public static bool M_WriteString(int _addr, string _strValue, int length)
        {
            if (_strValue.Length > 200)
            {
                return false;
            }
            if (_addr > 65535 || _addr < 0)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteString(_addr, _strValue, length);
        }
        /// <summary>
        /// 多个DINT写入
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static bool M_WriteDIntOrDWord_S(int _addr, int[] _val)
        {
            if (_addr > 65535 || _addr < 0 || _val.Length > 20)
            {
                return false;
            }
            if (m_PlcTcp == null || !m_PlcTcp.m_isConnectSucess)
            {
                return false;
            }
            return m_PlcTcp.M_WriteDIntOrDWord_S(_addr, _val);
        }
        #endregion

        /// <summary>
        /// 读取某一个标签【字典键名】指定类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="englishName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ReadValueByName<T>(string englishName, out T value)
        {
            DataSignalAddressConfig dataAddressConfig = DataSignalAddressUtil.DataSignalAddressConfigList.Find(cfg => cfg.EnglishName == englishName);
            if (dataAddressConfig == null)
            {
                throw new Exception($"没有配置或加载键名【{englishName}】,请检查配置");
            }
            return ReadValueByConfig(dataAddressConfig, out value);
        }

        public static bool ReadValueByConfig<T>(ParamMonitorConfig dataAddressConfig, out T value)
        {
            value =default(T);
            bool result = false;
            bool isReadDB = false;
            short dbNum = -1;
            if (dataAddressConfig.DB.StartsWith("DB", StringComparison.CurrentCultureIgnoreCase))
            {
                dbNum = short.Parse(dataAddressConfig.DB.Substring(2));
                isReadDB = true;
            }
            ushort offsetAddress = dataAddressConfig.Address;

            switch (dataAddressConfig.DataType)
            {
                case PlcDataType.Bool:
                    bool boolVal = false;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadBool(dbNum, offsetAddress, ref boolVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_ReadBool(offsetAddress, ref boolVal);
                    }
                    value = (T)(object)boolVal;
                    break;
                case PlcDataType.Byte:
                    byte byteVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadByte(dbNum, offsetAddress, ref byteVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        byte[] bytes = new byte[2];
                        result = M_ReadByte(offsetAddress, ref bytes);
                        byteVal = bytes[0];
                    }
                    value = (T)(object)byteVal;
                    break;
                case PlcDataType.Int:
                    short shortVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadWordOrInt(dbNum, offsetAddress, ref shortVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int shortValue = 0;
                        result = M_ReadWord(offsetAddress, ref shortValue);
                        shortVal = (short)shortValue;
                    }
                    value = (T)(object)shortVal;
                    break;
                case PlcDataType.Word:
                    ushort ushortVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        short tempUshort = 0;
                        result = DB_ReadWordOrInt(dbNum, offsetAddress, ref tempUshort);
                        ushortVal = (ushort)tempUshort;
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int shortValue = 0;
                        result = M_ReadWord(offsetAddress, ref shortValue);
                        ushortVal = (ushort)shortValue;
                    }
                    value = (T)(object)ushortVal;
                    break;
                case PlcDataType.DInt:
                    int intVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadDWordOrDInt(dbNum, offsetAddress, ref intVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int[] intArray = new int[1];
                        result = M_ReadDIntOrDWord(offsetAddress, ref intArray);
                        intVal = intArray[0];
                    }
                    value = (T)(object)intVal;
                    break;
                case PlcDataType.DWord:
                    uint uintVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        int intTemp = 0;
                        result = DB_ReadDWordOrDInt(dbNum, offsetAddress, ref intTemp);
                        uintVal = (uint)intTemp;
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int[] intArray = new int[1];
                        result = M_ReadDIntOrDWord(offsetAddress, ref intArray);
                        uintVal = (uint)intArray[0];
                    }
                    value = (T)(object)uintVal;
                    break;
                case PlcDataType.Real:
                    float floatVal = 0F;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadReal(dbNum, offsetAddress, ref floatVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_ReadReal(offsetAddress, ref floatVal);
                    }
                    value = (T)(object)floatVal;
                    break;
                case PlcDataType.LReal:
                    double doubleVal = 0D;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_Read_LReal(dbNum, offsetAddress, ref doubleVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_Read_LReal(offsetAddress, ref doubleVal);
                    }
                    value = (T)(object)doubleVal;
                    break;
                //case PlcDataType.String:
                //    string stringVal = string.Empty;
                //    if (isReadDB)  //DB块读写,已从字节数组中去掉前2个字节
                //    {
                //        result = DB_ReadString(dbNum, offsetAddress, (ushort)dataAddressConfig.DataLength, ref stringVal);
                //        //增加字符串判定，西门子字符串占用字节长度length+2:第一个字节代表最大长度，第二个字节代表字符串实际长度
                //        if (stringVal.Length >= 2)
                //        {
                //            stringVal = stringVal.Substring(2);
                //        }
                //    }
                //    else  //M区读取 【DataSourceNumber为单个M】
                //    {
                //        byte[] byteArrays = new byte[dataAddressConfig.DataLength];
                //        result = M_ReadByte_Any(offsetAddress, ref byteArrays);
                //        stringVal = Encoding.ASCII.GetString(byteArrays);
                //    }
                //    value = (T)(object)stringVal;
                //    break;
                //case PlcDataType.ByteArray:
                //    byte[] byteArray = new byte[dataAddressConfig.DataLength];
                //    if (isReadDB)  //DB块读写
                //    {
                //        result = DB_ReadByte_S(dbNum, offsetAddress, ref byteArray);
                //    }
                //    else  //M区读取 【DataSourceNumber为单个M】
                //    {
                //        result = M_ReadByte_Any(offsetAddress, ref byteArray);
                //    }
                //    value = (T)(object)byteArray;
                //    break;
                default:
                    throw new Exception($"不支持的数据类型【{typeof(T)}】，键名【{dataAddressConfig.ID}】,请检查输入参数");
            }
            return result;
        }
        /// <summary>
        /// 读取某一个地址表配置对应的数据值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataAddressConfig"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ReadValueByConfig<T>(DataSignalAddressConfig dataAddressConfig, out T value)
        {
            value = default(T);
            bool result = false;
            bool isReadDB = false;//是否读取DB块
            short dbNum = -1;
            if (dataAddressConfig.DataSourceNumber.StartsWith("DB", StringComparison.CurrentCultureIgnoreCase))
            {
                dbNum = short.Parse(dataAddressConfig.DataSourceNumber.Substring(2));
                isReadDB = true;
            }
            ushort offsetAddress = dataAddressConfig.OffsetAddress;
            switch (dataAddressConfig.DataType)
            {
                case PlcDataType.Bool:
                    bool boolVal = false;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadBool(dbNum, offsetAddress, ref boolVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_ReadBool(offsetAddress, ref boolVal);
                    }
                    value = (T)(object)boolVal;
                    break;
                case PlcDataType.Byte:
                    byte byteVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadByte(dbNum, offsetAddress, ref byteVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        byte[] bytes = new byte[2];
                        result = M_ReadByte(offsetAddress, ref bytes);
                        byteVal = bytes[0];
                    }
                    value = (T)(object)byteVal;
                    break;
                case PlcDataType.Int:
                    short shortVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadWordOrInt(dbNum, offsetAddress, ref shortVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int shortValue = 0;
                        result = M_ReadWord(offsetAddress, ref shortValue);
                        shortVal = (short)shortValue;
                    }
                    value = (T)(object)shortVal;
                    break;
                case PlcDataType.Word:
                    ushort ushortVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        short tempUshort = 0;
                        result = DB_ReadWordOrInt(dbNum, offsetAddress, ref tempUshort);
                        ushortVal = (ushort)tempUshort;
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int shortValue = 0;
                        result = M_ReadWord(offsetAddress, ref shortValue);
                        ushortVal = (ushort)shortValue;
                    }
                    value = (T)(object)ushortVal;
                    break;
                case PlcDataType.DInt:
                    int intVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadDWordOrDInt(dbNum, offsetAddress, ref intVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int[] intArray = new int[1];
                        result = M_ReadDIntOrDWord(offsetAddress, ref intArray);
                        intVal = intArray[0];
                    }
                    value = (T)(object)intVal;
                    break;
                case PlcDataType.DWord:
                    uint uintVal = 0;
                    if (isReadDB)  //DB块读写
                    {
                        int intTemp = 0;
                        result = DB_ReadDWordOrDInt(dbNum, offsetAddress, ref intTemp);
                        uintVal = (uint)intTemp;
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        int[] intArray = new int[1];
                        result = M_ReadDIntOrDWord(offsetAddress, ref intArray);
                        uintVal = (uint)intArray[0];
                    }
                    value = (T)(object)uintVal;
                    break;
                case PlcDataType.Real:
                    float floatVal = 0F;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadReal(dbNum, offsetAddress, ref floatVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_ReadReal(offsetAddress, ref floatVal);
                    }
                    value = (T)(object)floatVal;
                    break;
                case PlcDataType.LReal:
                    double doubleVal = 0D;
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_Read_LReal(dbNum, offsetAddress, ref doubleVal);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_Read_LReal(offsetAddress, ref doubleVal);
                    }
                    value = (T)(object)doubleVal;
                    break;
                case PlcDataType.String:
                    string stringVal = string.Empty;
                    if (isReadDB)  //DB块读写,已从字节数组中去掉前2个字节
                    {
                        result = DB_ReadString(dbNum, offsetAddress, (ushort)dataAddressConfig.DataLength, ref stringVal);
                        //增加字符串判定，西门子字符串占用字节长度length+2:第一个字节代表最大长度，第二个字节代表字符串实际长度
                        if (stringVal.Length >= 2)
                        {
                            byte[] temp = System.Text.Encoding.ASCII.GetBytes(stringVal[1].ToString());
                           
                            // Console.WriteLine(temp.GetValue(0).ToString());
                            int length = Convert.ToInt32(temp.GetValue(0).ToString(), 16);
                            stringVal = stringVal.Substring(2,length);
                        }
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        byte[] byteArrays = new byte[dataAddressConfig.DataLength];
                        result = M_ReadByte_Any(offsetAddress, ref byteArrays);
                      
                        stringVal = Encoding.ASCII.GetString(byteArrays);
                    }
                    value = (T)(object)stringVal;
                    break;
                case PlcDataType.ByteArray:
                    byte[] byteArray = new byte[dataAddressConfig.DataLength];
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_ReadByte_S(dbNum, offsetAddress, ref byteArray);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_ReadByte_Any(offsetAddress, ref byteArray);
                    }
                    value = (T)(object)byteArray;
                    break;
                default:
                    throw new Exception($"不支持的数据类型【{typeof(T)}】，键名【{dataAddressConfig.EnglishName}】,请检查输入参数");
            }
            return result;
        }

        /// <summary>
        /// 读取多个同类型的值,返回键值对字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKeys"></param>
        /// <returns></returns>
        public static Dictionary<string, T> ReadMultipleItem<T>(List<string> listKeys)
        {
            Dictionary<string, T> dict = new Dictionary<string, T>();
            for (int i = 0; i < listKeys.Count; i++)
            {
                T t = default(T);
                if (!ReadValueByName<T>(listKeys[i], out t))
                {
                    throw new Exception($"读取【{listKeys[i]}】的值时发生错误，请先检查标签是否存在 或者 PLC通信是否已断开");
                }
                dict.Add(listKeys[i], t);
            }
            return dict;
        }

        /// <summary>
        /// 读取DB块中连续的REAL数据
        /// </summary>
        /// <param name="startEnglishName"></param>
        /// <param name="listKeys"></param>
        /// <returns></returns>
        public static Dictionary<string, float> ReadSerialRealData(string startEnglishName, List<string> listKeys)
        {
            Dictionary<string, float> dict = new Dictionary<string, float>();
            DataSignalAddressConfig dataAddressConfig = DataSignalAddressUtil.DataSignalAddressConfigList.Find(cfg => cfg.EnglishName == startEnglishName);
            if (dataAddressConfig == null)
            {
                throw new Exception($"没有配置或加载键名【{startEnglishName}】,请检查配置");
            }
            short dbNum = short.Parse(dataAddressConfig.DataSourceNumber.Substring(2));
            float[] dataArray = GetSerialData(dbNum, dataAddressConfig.OffsetAddress, listKeys.Count);
            for (int i = 0; i < listKeys.Count; i++)
            {
                dict.Add(listKeys[i], dataArray[i]);
            }
            return dict;
        }

        /// <summary>
        /// 获取DB块连续个REAL值,数组个数:poleCount
        /// </summary>
        /// <param name="dbNum"></param>
        /// <param name="startAddress"></param>
        /// <param name="poleCount"></param>
        /// <returns></returns>
        private static float[] GetSerialData(short dbNum, int startAddress, int poleCount)
        {
            float[] destArray = new float[poleCount];
            int pageSize = (poleCount + 49) / 50;
            for (int i = 0; i < pageSize; i++)
            {
                int readCount = 50;
                if (i + 1 == pageSize)
                {
                    readCount = poleCount - 50 * i;
                }
                float[] floatValue = new float[readCount];
                //每次读取50个REAL
                DB_ReadReal_S(dbNum, startAddress, ref floatValue);
                System.Array.Copy(floatValue, 0, destArray, 50 * i, readCount);
                startAddress += 200;
            }
            return destArray;
        }

        /// <summary>
        /// 写入某一个标签【字典键名】指定的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="englishName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool WriteValueByName<T>(string englishName, T value)
        {
            DataSignalAddressConfig dataAddressConfig = DataSignalAddressUtil.DataSignalAddressConfigList.Find(cfg => cfg.EnglishName == englishName);
            if (dataAddressConfig == null)
            {
                throw new Exception($"没有配置或加载键名【{englishName}】,请检查配置");
            }
            return WriteValueByConfig(dataAddressConfig, value);
        }

        /// <summary>
        /// 写入某一个地址表配置指定类型的数据值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataAddressConfig"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool WriteValueByConfig<T>(DataSignalAddressConfig dataAddressConfig, T value)
        {
            bool result = false;
            bool isReadDB = false;//是否读取DB块
            short dbNum = -1;
            if (dataAddressConfig.DataSourceNumber.StartsWith("DB", StringComparison.CurrentCultureIgnoreCase))
            {
                dbNum = short.Parse(dataAddressConfig.DataSourceNumber.Substring(2));
                isReadDB = true;
            }
            ushort offsetAddress = dataAddressConfig.OffsetAddress;
            switch (dataAddressConfig.DataType)
            {
                case PlcDataType.Bool:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteBool(dbNum, offsetAddress, Convert.ToBoolean(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_WriteBool(offsetAddress, Convert.ToBoolean(value));
                    }
                    break;
                case PlcDataType.Byte:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteByte(dbNum, offsetAddress, Convert.ToByte(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        byte[] bytes = new byte[2] { Convert.ToByte(value), 0 };
                        result = M_WriteByte(offsetAddress, bytes.Select(b => (char)b).ToArray());
                    }
                    break;
                case PlcDataType.Int:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteWordOrInt(dbNum, offsetAddress, Convert.ToInt16(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_WriteWord(offsetAddress, Convert.ToInt16(value));
                    }
                    break;
                case PlcDataType.Word:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteWordOrInt(dbNum, offsetAddress, (short)Convert.ToUInt16(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_WriteWord(offsetAddress, Convert.ToUInt16(value));
                    }
                    break;
                case PlcDataType.DInt:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteDWordOrDInt(dbNum, offsetAddress, Convert.ToInt32(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_WriteDIntOrDWord(offsetAddress, Convert.ToInt32(value));
                    }
                    break;
                case PlcDataType.DWord:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteDWordOrDInt(dbNum, offsetAddress, (int)Convert.ToUInt32(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_WriteDIntOrDWord(offsetAddress, (int)Convert.ToUInt32(value));
                    }
                    break;
                case PlcDataType.Real:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteReal(dbNum, offsetAddress, Convert.ToSingle(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_WriteReal(offsetAddress, Convert.ToSingle(value));
                    }
                    break;
                case PlcDataType.LReal:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_Write_LReal(dbNum, offsetAddress, Convert.ToDouble(value));
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_Write_LReal(offsetAddress, Convert.ToDouble(value));
                    }
                    break;
                case PlcDataType.String:
                    if (isReadDB)  //DB块读写,写入字符串的时候 需要增加两个字节【最大长度 和 实际长度】
                    {
                        string strValue = Convert.ToString(value) ?? "";
                        strValue = Encoding.ASCII.GetString(new byte[] { (byte)dataAddressConfig.DataLength, (byte)strValue.Length }) + strValue;
                        strValue = strValue.PadRight(dataAddressConfig.DataLength + 2, '\0');
                        result = DB_WriteString(dbNum, offsetAddress, strValue);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        result = M_WriteString(offsetAddress, Convert.ToString(value));
                    }
                    break;
                case PlcDataType.ByteArray:
                    if (isReadDB)  //DB块读写
                    {
                        result = DB_WriteByte_S(dbNum, offsetAddress, (byte[])(object)value);
                    }
                    else  //M区读取 【DataSourceNumber为单个M】
                    {
                        byte[] array = (byte[])(object)value;
                        result = M_WriteByte(offsetAddress, array.Select(b => (char)b).ToArray());
                    }
                    break;
                default:
                    throw new Exception($"不支持的数据类型【{typeof(T)}】，键名【{dataAddressConfig.EnglishName}】,请检查输入参数");
            }
            return result;
        }
    }
}

