using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TherapyDashboard.Models
{
    public static class DataTableExtensions
    {
        /// To use these static methods outside of this file, add this to top of file:
        /// 
        /// using static symptest.Models.DataTableExtensions;
        /// 
        public static String GetDisplayName(Type type, PropertyInfo info, bool hasMetaDataAttribute)
        { /// via https://forums.asp.net/t/1698787.aspx?How+do+I+access+the+DisplayName+attribute+of+a+property+in+code+
          /// gets the [DisplayName] attribute string value of a specified property of a given object type
          /// usage: like normal. GetDisplayName(object.GetType(), object.GetType().GetProperties().First or however you want to specify which property in object, true if you know it has a display name false if you know it doesn't)
            if (!hasMetaDataAttribute)
            {
                object[] attributes = info.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    var displayName = (DisplayNameAttribute)attributes[0];
                    return displayName.DisplayName;
                }
                return info.Name;
            }
            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(type).Find(info.Name, true);
            DisplayNameAttribute displayAttribute =
            propDesc.Attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            return displayAttribute != null ? displayAttribute.DisplayName : info.Name;
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {/// Convert a list of this class into a DataTable object.
         /// Usage: anyList.ToDataTable<ClassName>()
            // make a DataTable
            DataTable outputTable = new DataTable(data[0].GetType().Name);
            //establish DataTable columns (header names)
            DataColumn col_placeholder;
            foreach (PropertyInfo property in data[0].GetType().GetProperties())
            {
                col_placeholder = new DataColumn(GetDisplayName(data[0].GetType(), property, true), property.PropertyType);
                outputTable.Columns.Add(col_placeholder);
            }
            //fill DataTable rows
            DataRow row_placeholder;
            foreach (var record in data)
            {
                row_placeholder = outputTable.NewRow();
                foreach (PropertyInfo property in data[0].GetType().GetProperties())
                {
                    row_placeholder[GetDisplayName(data[0].GetType(), property, true)] = property.GetValue(record);
                }
                outputTable.Rows.Add(row_placeholder);
            }
            return outputTable;
        }
        public static string ToHTMLTable(this DataTable dt)
        { /// via https://stackoverflow.com/questions/19682996/datatable-to-html-table
          /// Turns a DataTable into a basic HTML table, header row and all.
          /// Usage: dataTable.ToHTMLTable()
          /// Returns: a string of the HTML code
            string html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }
        public static void SetColumnsOrder(this DataTable table, params String[] columnNames)
        {
            /// via https://stackoverflow.com/questions/3757997/how-to-change-datatable-columns-order
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                table.Columns[columnName].SetOrdinal(columnIndex);
                columnIndex++;
            }
        }
        public static DataTable FilterByColumns(this DataTable input_table, string[] column_names)
        {
            /// Takes an input DataTable, and returns a new one with only the specified columns, in the order the column names are listed.
            DataView view = new DataView(input_table);
            DataTable output = view.ToTable(false, column_names);
            // properly order the remaining columns
            output.SetColumnsOrder(column_names);
            // ship out
            return output;
        }
    }
}