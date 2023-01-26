using Excel;
using System.Collections.Generic;
using System.Data;
using System.IO;

public static class ExcelRead
{
    // 获取excel表格里面的数据
    public static Data[] ReadDataExcel(string filePath)
    {
        //这里的用List存储 可避免一些空行的保存
        List<Data> list = new List<Data>();

        int columnNum = 0, rowNum = 0;//excel 行数 列数
        DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

        //这里i从1开始遍历， 因为第一行是标签名
        for (int i = 1; i < rowNum; i++)
        {
            //如果改行是空行 不保存
            if (IsEmptyRow(collect[i], columnNum)) continue;

            Data pointdata = new Data();
            int.TryParse(collect[i][0].ToString(), out pointdata.id);
            pointdata.title = collect[i][1].ToString();
            double.TryParse(collect[i][2].ToString(), out pointdata.lat);
            double.TryParse(collect[i][3].ToString(), out pointdata.lng);
           
            list.Add(pointdata);
        }
        return list.ToArray();
    }

    //判断是否是空行
    static bool IsEmptyRow(DataRow collect, int columnNum)
    {
        for (int i = 0; i < columnNum; i++)
        {
            if (!collect.IsNull(i)) return false;
        }
        return true;
    }

    /// <summary>
    /// 读取excel文件内容获取行数 列数 方便保存
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="columnNum">行数</param>
    /// <param name="rowNum">列数</param>
    /// <returns></returns>
    static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
    {
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();
        //Tables[0] 下标0表示excel文件中第一张表的数据
        columnNum = result.Tables[0].Columns.Count;
        rowNum = result.Tables[0].Rows.Count;
        return result.Tables[0].Rows;
    }
}
