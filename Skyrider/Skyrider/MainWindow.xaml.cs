using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.FSharp.Text.Lexing;

namespace Skyrider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string query =
                @"SELECT x, y, z   
                  FROM t1   
                  LEFT JOIN t2   
                  INNER JOIN t3 ON t3.ID = t2.ID   
                  WHERE x = 50 AND y = 20   
                  ORDER BY x ASC, y DESC, z;

                  SELECT x FROM y";

            Parse(query);
        }

        private void parse_Click(object sender, RoutedEventArgs e)
        {
            Parse(textBox.Text);
        }

        public void Parse(string query)
        {
            var ast = SqlHandler.ParseSql(query);

            foreach (var statement in ast.Statements)
            {
                Console.WriteLine(statement.Columns);
                Console.WriteLine(statement.Joins);
                Console.WriteLine(statement.OrderBy);
            }
        }
    }
}
