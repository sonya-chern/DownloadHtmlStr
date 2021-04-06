﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DownloadHtmlStr
{
    class MyDataBase
    {
        private readonly string connectionBd = "Data Source = C:\\Users\\Sofia\\Desktop\\C#\\DownloadHtmlStr\\TestDB.db; Version = 3; ";
        private void CreatEmptyDataBase()
        {
            if (!File.Exists(@"C:\Users\Sofia\Desktop\C#\DownloadHtmlStr\TestDB.db"))
            {
                SQLiteConnection.CreateFile(@"C:\Users\Sofia\Desktop\C#\DownloadHtmlStr\TestDB.db");
            }
            using (SQLiteConnection Connect = new SQLiteConnection(connectionBd))
            {
                string commandText = "CREATE TABLE IF NOT EXISTS [dbTableName] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [word] NVARCHAR(20), [countWord] INTEGER)";
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Connect.Open();
                Command.ExecuteNonQuery();
                Connect.Close();
            }
        }
        public void CreatDataBasesStatistics(Dictionary<string, int> wordAndItsRepetition)
        {
            CreatEmptyDataBase();
            using (SQLiteConnection Connect = new SQLiteConnection(connectionBd))
            {
                Connect.Open();
                foreach (var item in wordAndItsRepetition)
                {
                    string commandText = "INSERT INTO [dbTableName] ([word], [countWord]) VALUES('" + @item.Key + "', '" + @item.Value + "')";
                    SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                    Command.ExecuteNonQuery();
                }
                Connect.Close();
            }
        }
    }
}
